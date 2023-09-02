using Api.DTOs;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _AuthRepository;

        public AuthController(IAuthRepository IAuthRepository)
        {
            _AuthRepository = IAuthRepository;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthModel result = await _AuthRepository.Register(registerModel);
            return !result.isAuthenticated ? BadRequest(result.Message) : Ok(result);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> GetTokenAsync([FromBody] UserDtoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthModel result = await _AuthRepository.LogIn(model);
            return !result.isAuthenticated ? BadRequest(result.Message) : Ok(result);
        }
    }
}
