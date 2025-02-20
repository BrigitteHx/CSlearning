using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Api.DTOs.Course;
using StudentEnrollment.Data;
namespace StudentEnrollment.Api.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        // !!
        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var courses = await db.Courses.ToListAsync();
                return mapper.Map<List<CourseDto>>(courses);
            })
        .WithName("GetAllCourses")
        .WithOpenApi();

        // !!
        group.MapGet("/{id}", async Task<Results<Ok<CourseDto>, NotFound>> (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                return await db.Courses.AsNoTracking()
                        .FirstOrDefaultAsync(model => model.Id == id)
                    is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDto>(model))
                    : TypedResults.NotFound();
           }).WithName("GetCourseById")
            .WithOpenApi();

        // !!
        group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, CourseDto courseDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var foundModel = await db.Courses.FindAsync(id);
                if (foundModel is null)
                    return TypedResults.NotFound();

                mapper.Map(courseDto, foundModel);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            })
            .WithName("UpdateCourse")
            .WithOpenApi();

        // !!
        group.MapPost("/", async (CreateCourseDto courseDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var course = mapper.Map<Course>(courseDto);
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Course/{course.Id}",course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi();
    }
}
