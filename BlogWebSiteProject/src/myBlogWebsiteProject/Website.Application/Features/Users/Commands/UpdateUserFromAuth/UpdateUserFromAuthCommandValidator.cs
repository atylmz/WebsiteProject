using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Users.Commands.UpdateUserFromAuth
{
    public class UpdateUserFromAuthCommandValidator : AbstractValidator<UpdateUserFromAuthCommand>
    {
        public UpdateUserFromAuthCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.LastName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
            RuleFor(c => c.NewPassword).NotEmpty().MinimumLength(6).Equal(c => c.Password);
        }
    }
}
