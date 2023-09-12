using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<cartItem>
    {
        public void Configure(EntityTypeBuilder<cartItem> builder)
        {
           
        }
    }
}
