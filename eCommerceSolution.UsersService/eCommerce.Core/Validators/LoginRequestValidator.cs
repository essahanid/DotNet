using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() {
            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Invalid Email address format");
            RuleFor(o => o.Password)
           .NotEmpty().WithMessage("Password is required");
        }
    }
}
