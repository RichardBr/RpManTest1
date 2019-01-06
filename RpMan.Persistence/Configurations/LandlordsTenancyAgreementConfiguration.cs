using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpMan.Domain.Entities;

namespace RpMan.Persistence.Configurations
{
    public class LandlordsTenancyAgreementConfiguration : IEntityTypeConfiguration<LandlordsTenancyAgreement>
    {
        public void Configure(EntityTypeBuilder<LandlordsTenancyAgreement> builder)
        {
            builder.HasKey(e => new { e.TenancyAgreementId, e.LandlordId });
        }

    }
}
