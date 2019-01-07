using System;
using System.Collections.Generic;
using System.Text;
using RpMan.Domain.Entities;

namespace RpMan.Persistence.Infrastructure
{
    // below is used in Seed Initializer -- see northwind tutorial sample for use!

    internal static class TenantsTenancyAgreementExtensions
    {
        public static TenancyAgreement AddTenantsTenancyAgreements(this TenancyAgreement tenancyAgreement, params TenantsTenancyAgreement[] tenantsTenancyAgreements)
        {
            foreach (var tenantsTenancyAgreement in tenantsTenancyAgreements)
            {
                tenancyAgreement.TenantsTenancyAgreements.Add(tenantsTenancyAgreement);
            }

            return tenancyAgreement;
        }
        public static TenancyAgreement AddLandlordsTenancyAgreements(this TenancyAgreement tenancyAgreement, params LandlordsTenancyAgreement[] landlordsTenancyAgreements)
        {
            foreach (var landlordsTenancyAgreement in landlordsTenancyAgreements)
            {
                tenancyAgreement.LandlordsTenancyAgreements.Add(landlordsTenancyAgreement);
            }

            return tenancyAgreement;
        }
    }
}
