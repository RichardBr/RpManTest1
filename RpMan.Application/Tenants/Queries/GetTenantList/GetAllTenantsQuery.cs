using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RpMan.Persistence;

namespace RpMan.Application.Tenants.Queries.GetTenantList
{
    public class GetAllTenantsQuery : IRequest<TenantListViewModel>
    {
    }

    public class GetAllTenantsQueryHandler : IRequestHandler<GetAllTenantsQuery, TenantListViewModel>
    {
        private readonly RpManDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTenantsQueryHandler(RpManDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TenantListViewModel> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var tenants = await _context.Tenants.OrderBy(p => p.Firstname).ToListAsync(cancellationToken);

            var model = new TenantListViewModel
            {
                Tenants = _mapper.Map<IEnumerable<TenantDto>>(tenants),
                CreateEnabled = true
            };

            return model;
        }
    }
}
