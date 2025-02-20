using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Api.DTOs.Enrollment;
using StudentEnrollment.Data;
namespace StudentEnrollment.Api.Endpoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollment").WithTags(nameof(Enrollment));

        // aangepast
        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var enrollments = await db.Enrollments.ToListAsync();
                return mapper.Map<List<EnrollmentDto>>(enrollments);
            })
            .WithName("GetAllEnrollments")
            .WithOpenApi();

        // aangepast
        group.MapGet("/{id}", async Task<Results<Ok<EnrollmentDto>, NotFound>> (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                return await db.Enrollments.AsNoTracking()
                        .FirstOrDefaultAsync(model => model.Id == id)
                    is Enrollment model
                    ? TypedResults.Ok(mapper.Map<EnrollmentDto>(model))
                    : TypedResults.NotFound();
            })
            .WithName("GetEnrollmentById")
            .WithOpenApi();

        // aangepast
        group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, EnrollmentDto enrollmentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var foundModel = await db.Enrollments.FindAsync(id);
                if (foundModel is null)
                    return TypedResults.NotFound();

                mapper.Map(enrollmentDto, foundModel);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            })
            .WithName("UpdateEnrollment")
            .WithOpenApi();

        // aangepast
        group.MapPost("/", async (CreateEnrollmentDto enrollmentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
            {
                var enrollment = mapper.Map<Enrollment>(enrollmentDto);
                db.Enrollments.Add(enrollment);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
            })
            .WithName("CreateEnrollment")
            .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Enrollments
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEnrollment")
        .WithOpenApi();
    }
}
