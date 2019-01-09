using MediatR;

namespace RpMan.Application.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantCommand : IRequest
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Middlenames { get; set; }
        public string Lastname { get; set; }


        //public string Address { get; set; }
        //public string City { get; set; }
        //public string CompanyName { get; set; }
        //public string ContactName { get; set; }
        //public string ContactTitle { get; set; }
        //public string Country { get; set; }
        //public string Fax { get; set; }
        //public string Phone { get; set; }
        //public string PostalCode { get; set; }
        //public string Region { get; set; }
    }
}
