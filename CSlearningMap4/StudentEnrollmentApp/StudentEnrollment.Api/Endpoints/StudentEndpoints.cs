﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Api.DTOs.Course;
using StudentEnrollment.Api.DTOs.Enrollment;
using StudentEnrollment.Api.DTOs.Student;
using StudentEnrollment.Api.Filters;
using StudentEnrollment.Api.Services;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Api.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (IStudentRepository repo, IMapper mapper) =>
        {
            var students = await repo.GetAllAsync(); ;
            var data = mapper.Map<List<StudentDto>>(students);
            return data;
        })
        .AllowAnonymous()
        .WithTags(nameof(Student))
        .WithName("GetAllStudents")
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDto>(model))
                    : Results.NotFound();
        })
        .AllowAnonymous()
        .WithTags(nameof(Student))
        .WithName("GetStudentById")
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapGet("/api/Student/GetDetails/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDetailsDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Student))
        .WithName("GetStudentDetailsById")
        .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Student/{id}", [Authorize(Roles = "Administrator")] async (int Id, StudentDto studentDto, IStudentRepository repo, IMapper mapper, IValidator<StudentDto> validator, IFileUpload fileUpload) =>
        {
            var validationResult = await validator.ValidateAsync(studentDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var foundModel = await repo.GetAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here
            mapper.Map(studentDto, foundModel);

            if (studentDto.ProfilePicture != null)
            {
                foundModel.Picture = fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OriginalFileName);
            }

            await repo.UpdateAsync(foundModel);
            return Results.NoContent();
        })
        .WithTags(nameof(Student))
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", [Authorize(Roles = "Administrator")] async (CreateStudentDto studentDto, IStudentRepository repo, IMapper mapper, IValidator<CreateStudentDto> validator, IFileUpload fileUpload) =>
        {
            var validationResult = await validator.ValidateAsync(studentDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var student = mapper.Map<Student>(studentDto);

            student.Picture = fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OriginalFileName);

            await repo.AddAsync(student);
            return Results.Created($"/Students/{student.Id}", student);
        })
        .AddEndpointFilter<ValidatationFilter<CreateStudentDto>>()
        .AddEndpointFilter<LoggingFilter>()
        .WithTags(nameof(Student))
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{id}", [Authorize(Roles = "Administrator")] async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.DeleteAsync(Id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Student))
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}