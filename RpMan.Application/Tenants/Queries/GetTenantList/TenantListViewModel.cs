using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Application.Tenants.Queries.GetTenantList
{
    public class TenantListViewModel
    {
        public IEnumerable<TenantDto> Tenants { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
