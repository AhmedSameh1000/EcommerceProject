﻿using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("UserWithHisRoles/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserWithHisRoles(string id)
        {
            var UserRoles=await userRepository.GetUserRoles(id);

            return Ok(UserRoles);
        }  
        [HttpPost("SetUserRoles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetUserRoles(UserRolesDTO userRoles)
        {
            await userRepository.SetUserRoles(userRoles);
            return Ok(userRoles);
        }



        [HttpGet("AllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Getusers([FromQuery] PaginationParams? param)
        {
            var Users=await userRepository.GetUsers(param);
            return Ok(Users);
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
