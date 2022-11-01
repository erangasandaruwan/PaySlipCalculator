using FluentValidation;
using PaySlip.Application.Core.Util;
using PaySlip.Domain.Model;

namespace PaySlip.Application.Validator
{
    public class PaySlipRequestInfoValidator : AbstractValidator<PaySlipRequestInfo>
    {
        public PaySlipRequestInfoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().NotEmpty()
                .WithMessage("First name cannot be null or empty.");

            RuleFor(x => x.LastName)
                .NotNull().NotEmpty()
                .WithMessage("Last name cannot be null or empty.");

            RuleFor(x => x.AnnualSalary)
                .NotNull()
                .WithMessage("Annual salary name cannot be null.");
            RuleFor(x => x.AnnualSalary)
                .GreaterThan(0)
                .WithMessage("Annual salary must be greater than zero.");

            RuleFor(x => x.SuperRate)
                .NotNull()
                .WithMessage("Super rate name cannot be null.");
            RuleFor(x => x.SuperRate)
                .InclusiveBetween(0, 50)
                .WithMessage("Super rate must be between 0% -50% inclusive");

            RuleFor(x => x.PayPeriod)
                .NotNull().NotEmpty()
                .WithMessage("Pay period cannot be null or empty.");
            RuleFor(x => x.PayPeriod)
                .Must(Month.IsValidMonth)
                .WithMessage("Pay period cannot be null or empty.");
        }
    }
}
