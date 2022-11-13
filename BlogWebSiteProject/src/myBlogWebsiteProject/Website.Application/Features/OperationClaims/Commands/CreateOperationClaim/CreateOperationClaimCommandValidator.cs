using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MinimumLength(2);
        }
    }
}
