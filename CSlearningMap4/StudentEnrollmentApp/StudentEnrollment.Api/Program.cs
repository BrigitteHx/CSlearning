
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Api.Configurations;
using StudentEnrollment.Data;
using StudentEnrollment.Api.Endpoints;

namespace StudentEnrollment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection");
            builder.Services.AddDbContext<StudentEnrollmentDbContext>(options => { options.UseSqlServer(conn); });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MapperConfig));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapStudentEndpoints();

            app.MapEnrollmentEndpoints();

            app.MapCourseEndpoints();

            app.Run();
        } 
    }
} 
