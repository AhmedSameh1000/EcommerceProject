﻿
namespace Core.DTOs
{
    public class UserRolesDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public List<RolesDTo> Roles { get; set; }
    }
}