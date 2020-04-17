using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NativeApps2WindowsPlaneBackend_2.Data.DbConfig
{
    public class TravelGroupConfig : IEntityTypeConfiguration<TravelGroup>
    {
        public void Configure(EntityTypeBuilder<TravelGroup> builder)
        {
            builder.ToTable("TravelGroup");
        }
    }
}