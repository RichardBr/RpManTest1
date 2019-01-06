using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpMan.Domain.Entities;

namespace RpMan.Persistence.Configurations
{
    public class TenantsTenancyAgreementConfiguration : IEntityTypeConfiguration<TenantsTenancyAgreement>
    {
        public void Configure(EntityTypeBuilder<TenantsTenancyAgreement> builder)
        {
            builder.HasKey(e => new { e.TenancyAgreementId, e.TenantId });
            builder.Property(e => e.Dummy).IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(1);
        }

    }
}
