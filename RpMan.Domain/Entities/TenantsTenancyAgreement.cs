using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    public class TenantsTenancyAgreement
    {
        public int TenantId { get; set; }
        public int TenancyAgreementId { get; set; }
        public string Dummy { get; set; }
    }
}
