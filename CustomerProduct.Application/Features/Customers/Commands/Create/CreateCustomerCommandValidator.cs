using FluentValidation;

namespace CustomerProduct.Application.Features.Customers
{
    class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand> 
    {

        public CreateCustomerCommandValidator()
        {
            RuleFor(p => p.FamilyName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(p => p.GivenName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20characters.");
        }


    }
}
