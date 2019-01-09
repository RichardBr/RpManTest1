using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RpMan.Application.Exceptions;
using RpMan.Domain.Entities;
using RpMan.Persistence;

namespace RpMan.Application.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, Unit>
    {
        private readonly RpManDbContext _context;

        public UpdateTenantCommandHandler(RpManDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tenants
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tenant), request.Id);
            }

            entity.Firstname = request.Firstname;
            entity.Middlenames = request.Middlenames;
            entity.Lastname = request.Lastname;

            //entity.Address = request.Address;
            //entity.City = request.City;
            //entity.CompanyName = request.CompanyName;
            //entity.ContactName = request.ContactName;
            //entity.ContactTitle = request.ContactTitle;
            //entity.Country = request.Country;
            //entity.Fax = request.Fax;
            //entity.Phone = request.Phone;
            //entity.PostalCode = request.PostalCode;

            _context.Tenants.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
