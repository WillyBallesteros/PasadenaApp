using Core.Payload;
using FluentValidation;

namespace Core.Validation
{
    public class RegisterPayloadValidator : AbstractValidator<RegisterPayload>
    {
        public RegisterPayloadValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Nombres).NotEmpty();
            RuleFor(x => x.Apellidos).NotEmpty();
        }
    }
}
