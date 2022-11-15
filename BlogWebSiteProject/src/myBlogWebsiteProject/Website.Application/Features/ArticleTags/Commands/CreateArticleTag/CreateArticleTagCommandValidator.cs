using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleTags.Commands.CreateArticleTag
{
    public class CreateArticleTagCommandValidator : AbstractValidator<CreateArticleTagCommand>
    {
        public CreateArticleTagCommandValidator()
        {
            RuleFor(r=>r.ArticleId).NotEmpty();
            RuleFor(r=>r.TagId).NotEmpty();
        }
    }
}
