using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpMan.Domain.Entities;

namespace RpMan.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(8);
            builder.Property(e => e.Firstname).HasMaxLength(60);
            builder.Property(e => e.Middlenames).HasMaxLength(60);
            builder.Property(e => e.Lastname).IsRequired().HasMaxLength(60);
        }


    }
}
