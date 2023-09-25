using Api.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using InfraStructure.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public UserRepository(
            UserManager<User> userManager, IMapper mapper,AppDbContext context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task DeleteUser(string id)
        {
            var User=await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(User);
        }

        public async Task<UserRolesDTO> GetUserRoles(string id)
        {
            var UserSelected = await userManager.FindByIdAsync(id);
            if (UserSelected is null) return null;

            var Roles =context.Roles.ToListAsync();

            var UserRolesToReturn = new UserRolesDTO()
            {
                UserId = UserSelected.Id,
                UserName=UserSelected.FirstName+" " +UserSelected.LastName,
                Roles=Roles.Result.Select(role=>new RolesDTo()
                {
                    RoleId=role.Id,
                    RoleName=role.Name,
                    IsSelected=userManager.IsInRoleAsync(UserSelected,role.Name).Result
                }).ToList(),
            };

            return UserRolesToReturn;
        }

        public async Task SetUserRoles(UserRolesDTO userRoles)
        {
            var UserSelected = await userManager.FindByIdAsync(userRoles.UserId);
            if (UserSelected is null) return ;


            var UserRoles = await userManager.GetRolesAsync(UserSelected);
            foreach (var Role in userRoles.Roles)
            {
                if (UserRoles.Any(r => r == Role.RoleName) && !Role.IsSelected)
                    await userManager.RemoveFromRoleAsync(UserSelected, Role.RoleName);

                if (!UserRoles.Any(r => r == Role.RoleName) && Role.IsSelected)
                    await userManager.AddToRoleAsync(UserSelected, Role.RoleName);
            }
        }




        public async Task<UserPaginationResponse> GetUsers(PaginationParams @params)
        {
            var _itemsPerPage = 6f;
            var PageCount = Math.Ceiling(userManager.Users.Count() / _itemsPerPage);


            var Users = userManager.Users
              .Skip((@params.page.Value - 1) * (int)_itemsPerPage)
              .Take((int)_itemsPerPage);

            if (!string.IsNullOrEmpty(@params.Search))
            {
                Users = Users.Where(p => p.Email.ToLower().Contains(@params.Search.ToLower()));
            }

            var AllUsers = await Users.Where(c=>c.Email!="Admin@gmail.com").ToListAsync();

            var UsersToReturn = AllUsers.Select(c=>new UserDto 
            { 
            
                Id = c.Id,
                City = c.City,
                Email=c.Email,
                FirstName = c.FirstName ,
                LastName = c.LastName,
                Roles = userManager.GetRolesAsync(c).Result.ToList()
            }).ToList();


            //var ReturnUsers = mapper.Map<List<UserDto>>(AllUsers);



            var UserResponse = new UserPaginationResponse
            {
                Users = UsersToReturn,
                PageCount = (int)PageCount,
                itemsPerPage = _itemsPerPage,
                ProductsCount = userManager.Users.Count(),
                currentPage = @params.page.Value
            };
            return UserResponse;



        }


    }

}
