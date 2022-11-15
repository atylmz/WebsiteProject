using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleTags.Commands.UpdateArticleTag
{
    public class UpdateArticleTagCommandValidator : AbstractValidator<UpdateArticleTagCommand>
    {
        public UpdateArticleTagCommandValidator()
        {
            RuleFor(r => r.ArticleId).NotEmpty();
            RuleFor(r => r.TagId).NotEmpty();
        }
    }
}
