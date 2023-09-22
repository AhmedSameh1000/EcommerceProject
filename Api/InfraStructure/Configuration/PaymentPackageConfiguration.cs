using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Config
{
    public class PaymentPackageConfiguration : IEntityTypeConfiguration<PaymentPackage>
    {
        public void Configure(EntityTypeBuilder<PaymentPackage> builder)
        {

            builder
           .HasOne(pp => pp.Reciver)
           .WithMany()
           .HasForeignKey(pp => pp.ReciverId)
           .IsRequired(false);
        }
    }
}
