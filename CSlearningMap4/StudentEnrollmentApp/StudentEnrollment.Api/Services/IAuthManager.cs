using Microsoft.AspNetCore.Identity;
using StudentEnrollment.Api.DTOs.Authentication;
using static StudentEnrollment.Api.Endpoints.AuthenticationEndpoints;

namespace StudentEnrollment.Api.Services
{
    public interface IAuthManager
    {
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<IEnumerable<IdentityError>> Register(RegisterDto registerDto);
    }
}