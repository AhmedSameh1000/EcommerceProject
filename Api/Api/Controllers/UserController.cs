using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet("AllUsers")]
        public async Task<IActionResult> Getusers([FromQuery] PaginationParams? param)
        {
            var Users=await userRepository.GetUsers(param);
            return Ok(Users);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
