using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    public class LandlordsTenancyAgreement
    {
        public int LandlordId { get; set; }
        public int TenancyAgreementId { get; set; }
        public string Dummy { get; set; }
    }
}
