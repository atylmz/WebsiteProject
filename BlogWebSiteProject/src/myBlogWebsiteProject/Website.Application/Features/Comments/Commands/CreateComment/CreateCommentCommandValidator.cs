using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(2).MaximumLength(20);
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
