using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.Api.DTOs.Course;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Api.Endpoints
{
    public static class AuthenticationEndpoints
    {

        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/login/", async (LoginDto loginDto, UserManager<SchoolUser> userManager) =>
                {
                    var user = await userManager.FindByEmailAsync(loginDto.Username);
                    if (user is null)
                    {
                        return Results.Unauthorized();
                    }

                    bool isValidCredentials = await userManager.CheckPasswordAsync(user, loginDto.Password);

                    if (!isValidCredentials)
                    {
                        return Results.Unauthorized();
                    }

                    // token

                    return Results.Ok();
                })
                .WithTags("Authentication")
                .WithName("Login")
                .Produces(StatusCodes.Status200OK);
        }

        public class LoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
