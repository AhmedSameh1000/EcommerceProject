using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Seeding
{
    public class Initializer: IInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext _context;

        public Initializer(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext Context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = Context;
        }


        public async Task Intialize()
        {       
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
         
            }

            if(!await roleManager.RoleExistsAsync(Constant.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Constant.Admin));
                await roleManager.CreateAsync(new IdentityRole(Constant.Moderator));
                await roleManager.CreateAsync(new IdentityRole(Constant.User));
                var admin = new User()
                {
                    FirstName = "Ahmed",
                    LastName = "Sameh",
                    Email="Admin@gmail.com",
                    UserName= "Admin@gmail.com",
                    City="Alexandria",
                    PhoneNumber="01092532838",
                };

                var Result = await userManager.CreateAsync(admin, "ahmeds1490");

                if (Result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constant.Admin);
                    await userManager.AddToRoleAsync(admin, Constant.Moderator);
                    await userManager.AddToRoleAsync(admin, Constant.User);
                }
            }
      


        }  
    }
}

