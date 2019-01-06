using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    public class Tenant
    {
        public Tenant()
        {
            TenantsTenancyAgreements = new HashSet<TenantsTenancyAgreement>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlenames { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Lookups


        // Children
        public ICollection<TenantsTenancyAgreement> TenantsTenancyAgreements { get; private set; }
    }
}
