using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleMetas.Commands.CreateArticleMeta
{
    public class CreateArticleMetaCommandValidator : AbstractValidator<CreateArticleMetaCommand>
    {
        public CreateArticleMetaCommandValidator()
        {
            RuleFor(r=>r.Content).NotEmpty();
            RuleFor(r=>r.Key).NotEmpty();
        }
    }
}
