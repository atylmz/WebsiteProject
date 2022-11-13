using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Tags.Commands.CreateTag
{
    public class CreateTagCommanValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommanValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(2).MaximumLength(9);
        }
    }
}
