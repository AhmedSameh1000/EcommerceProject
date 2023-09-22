
using Core.Models;
using InfraStructure.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfraStructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
   

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet <cartItem> cartItems { get; set; }
        public DbSet <OrderHeader> OrderHeaders { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }
        public DbSet <PaymentPackage>  PaymentPackages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }
    }

}


