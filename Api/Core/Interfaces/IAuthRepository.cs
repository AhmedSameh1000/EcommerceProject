using Api.DTOs;
using Core.DTOs;
using Core.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthModel> LogIn(UserDtoModel Login);
        Task<AuthModel> Register(RegisterModel Register);
        Task<JwtSecurityToken> CreateToken(User user);
    }
}
