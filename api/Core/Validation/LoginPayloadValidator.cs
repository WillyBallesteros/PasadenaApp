using Core.Payload;
using FluentValidation;

namespace Core.Validation
{
    public class LoginPayloadValidator : AbstractValidator<LoginPayload>
    {
        public LoginPayloadValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
