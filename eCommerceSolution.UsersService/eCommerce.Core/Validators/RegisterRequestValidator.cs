namespace eCommerce.Core.Validators;

using eCommerce.Core.DTO;
using FluentValidation;
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(o => o.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Invalid Email address format");
        RuleFor(o => o.Password)
          .NotEmpty().WithMessage("Password is required");
        RuleFor(o => o.PersonName)
        .NotEmpty().WithMessage("PersonName is required").Length(1,50).WithMessage("Length between 1 and 50");
        RuleFor(o => o.Gender).NotNull().IsInEnum().WithMessage("Invalid gender option"); ;
      ;
    }
}
