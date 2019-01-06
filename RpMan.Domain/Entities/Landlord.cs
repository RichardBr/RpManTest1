using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    public class Landlord
    {
        public Landlord()
        {
            LandlordsTenancyAgreements = new HashSet<LandlordsTenancyAgreement>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlenames { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Lookups


        // Children
        public ICollection<LandlordsTenancyAgreement> LandlordsTenancyAgreements { get; private set; }


    }
}
