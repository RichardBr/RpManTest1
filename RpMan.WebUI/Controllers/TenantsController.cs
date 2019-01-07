using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpMan.Persistence;

namespace RpMan.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly RpManDbContext _context;

        public TenantsController(RpManDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return new string[] { "value1-Tenant", "value2-Tenant" };
            var tenants = await _context.Tenants.ToListAsync();
            return Ok(tenants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tenant = await _context.Tenants.Include(i=>i.TenantsTenancyAgreements).FirstOrDefaultAsync(x=>x.Id == id);

            if (tenant != null)
            {
                return Ok(tenant);
            }

            return BadRequest();
        }
    }
}