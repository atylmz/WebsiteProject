using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.LastName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
        }
    }
}
