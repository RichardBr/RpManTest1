using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpMan.Application.Tenants.Commands.UpdateTenant;
using RpMan.Application.Tenants.Queries.GetTenantList;
using RpMan.Persistence;

namespace RpMan.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly RpManDbContext _context;
        private readonly IMediator _mediator;

        public TenantsController(RpManDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    // return new string[] { "value1-Tenant", "value2-Tenant" };
        //    var tenants = await _context.Tenants.ToListAsync();
        //    return Ok(tenants);
        //}

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

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationtoken)
        //{
        //    var result = await _mediator.Send(new GetAllTenantsQuery(), cancellationtoken);
        //    return Ok(result);
        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<TenantListViewModel>> GetAll()
        {
            var result = await _mediator.Send(new GetAllTenantsQuery());

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateTenantCommand command)
        {
            if (command.Id == null)
            {
                command.Id = id;
            }

            var result = await _mediator.Send(command);

            return NoContent();
        }

    }
}