using CustomerApi.Dtos;
using FluentValidation;

namespace CustomerApi.Validators;

public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(20);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(20);

        RuleFor(x => x.Email)
            .MaximumLength(50)
            .EmailAddress().WithMessage("Email is not valid.")
            .When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}
