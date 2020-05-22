using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.DbConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasOne(o => o.Passenger).WithMany(p => p.Orders);
        }
    }
}