using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    class TenancyAgreement
    {
        public TenancyAgreement()
        {
            TenantsTenancyAgreements = new HashSet<TenantsTenancyAgreement>();
            LandlordsTenancyAgreements = new HashSet<LandlordsTenancyAgreement>();
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FixedTermEndDate { get; set; }
        public decimal RentAmount { get; set; }
        public int RentPeriod { get; set; }

        // Lookups
        public Property Property { get; set; }

        // Children
        public ICollection<TenantsTenancyAgreement> TenantsTenancyAgreements { get; private set; }
        public ICollection<LandlordsTenancyAgreement> LandlordsTenancyAgreements { get; private set; }
    }
}
