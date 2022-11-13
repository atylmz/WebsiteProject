using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleMetas.Commands.UpdateArticleMeta
{
    public class UpdateArticleMetaCommandValidator : AbstractValidator<UpdateArticleMetaCommand>
    {
        public UpdateArticleMetaCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Content).NotEmpty();
            RuleFor(r => r.Key).NotEmpty();
        }
    }
}
