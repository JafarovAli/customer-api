using CustomerApi.Dtos;
using FluentValidation;

namespace CustomerApi.Validators;

public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .MaximumLength(20);

        RuleFor(x => x.LastName)
            .MaximumLength(20);

        RuleFor(x => x.Email)
            .MaximumLength(50)
            .EmailAddress().WithMessage("Email is not valid.")
            .When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}
