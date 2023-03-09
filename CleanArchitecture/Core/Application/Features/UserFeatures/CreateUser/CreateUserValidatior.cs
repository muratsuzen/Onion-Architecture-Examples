using FluentValidation;
using System;
using System.Linq;

namespace Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserValidatior : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidatior()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(3).MaximumLength(50);
        }
    }
}
