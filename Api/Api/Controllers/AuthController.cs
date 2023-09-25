using Api.DTOs;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _AuthRepository;
        private readonly UserManager<User> _userManager;

        public AuthController(IAuthRepository IAuthRepository, UserManager<User> userManager)
        {
            _AuthRepository = IAuthRepository;
            _userManager = userManager;
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
        public async Task<IActionResult> GetTokenAsync([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthModel result = await _AuthRepository.LogIn(model);
            return !result.isAuthenticated ? BadRequest(result.Message) : Ok(result);
        }

        [HttpGet("UserData/{id}")]
        public async Task<IActionResult> GetUserData(string id)
        {
            User User = await _AuthRepository.GetUser(id);
            return Ok(User);
        }
    }
}