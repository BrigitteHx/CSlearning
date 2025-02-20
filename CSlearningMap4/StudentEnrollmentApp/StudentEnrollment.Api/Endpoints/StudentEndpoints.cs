using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Api.DTOs.Student;
using StudentEnrollment.Data;
namespace StudentEnrollment.Api.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        // aangepast
        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var students = await db.Students.ToListAsync();
                return mapper.Map<List<StudentDto>>(students);
            })
            .WithName("GetAllStudents")
            .WithOpenApi();

        // aangepast
        group.MapGet("/{id}", async Task<Results<Ok<StudentDto>, NotFound>> (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                return await db.Students.AsNoTracking()
                        .FirstOrDefaultAsync(model => model.Id == id)
                    is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDto>(model))
                    : TypedResults.NotFound();
            })
            .WithName("GetStudentById")
            .WithOpenApi();

        // aangepast
        group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, StudentDto studentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var foundModel = await db.Students.FindAsync(id);
                if (foundModel is null)
                    return TypedResults.NotFound();

                mapper.Map(studentDto, foundModel);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            })
            .WithName("UpdateStudent")
            .WithOpenApi();

        // aangepast
        group.MapPost("/", async (CreateStudentDto studentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var student = mapper.Map<Student>(studentDto);
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Student/{student.Id}", student);
            })
            .WithName("CreateStudent")
            .WithOpenApi();


        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
