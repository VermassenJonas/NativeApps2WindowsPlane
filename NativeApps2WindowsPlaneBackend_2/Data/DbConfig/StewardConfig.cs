using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NativeApps2WindowsPlaneBackend_2.Data.DbConfig
{
    public class StewardConfig : IEntityTypeConfiguration<Steward>
    {
        public void Configure(EntityTypeBuilder<Steward> builder)
        {
            builder.ToTable("Steward");
            builder.HasKey(s => s.PersonnelNumber);
        }
    }
}