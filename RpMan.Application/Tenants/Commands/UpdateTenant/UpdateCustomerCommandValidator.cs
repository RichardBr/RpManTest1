using FluentValidation;
using FluentValidation.Validators;

namespace RpMan.Application.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
    {
        public UpdateTenantCommandValidator()
        {
            RuleFor(x => x.Firstname).MaximumLength(3);
            RuleFor(x => x.Middlenames).MaximumLength(60);
            RuleFor(x => x.Lastname).MaximumLength(15).NotEmpty();


            //RuleFor(x => x.Id).MaximumLength(5).NotEmpty();
            //RuleFor(x => x.Address).MaximumLength(60);
            //RuleFor(x => x.City).MaximumLength(15);
            //RuleFor(x => x.CompanyName).MaximumLength(40).NotEmpty();
            //RuleFor(x => x.ContactName).MaximumLength(30);
            //RuleFor(x => x.ContactTitle).MaximumLength(30);
            //RuleFor(x => x.Country).MaximumLength(15);
            //RuleFor(x => x.Fax).MaximumLength(24).NotEmpty();
            //RuleFor(x => x.Phone).MaximumLength(24).NotEmpty();
            //RuleFor(x => x.PostalCode).MaximumLength(10);
            //RuleFor(x => x.Region).MaximumLength(15);

            //RuleFor(c => c.PostalCode).Matches(@"^\d{4}$")
            //    .When(c => c.Country == "Australia")
            //    .WithMessage("Australian Postcodes have 4 digits");

            //RuleFor(c => c.Phone)
            //    .Must(HaveQueenslandLandLine)
            //    .When(c => c.Country == "Australia" && c.PostalCode.StartsWith("4"))
            //    .WithMessage("Tenants in QLD require at least one QLD landline.");
        }

        private static bool HaveQueenslandLandLine(UpdateTenantCommand model, string phoneValue, PropertyValidatorContext ctx)
        {
            // return model.Phone.StartsWith("07") || model.Fax.StartsWith("07");
            return true;

        }
    }
}
