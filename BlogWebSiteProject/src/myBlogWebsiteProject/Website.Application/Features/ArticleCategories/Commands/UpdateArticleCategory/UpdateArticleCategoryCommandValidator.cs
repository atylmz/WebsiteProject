using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleCategories.Commands.UpdateArticleCategory
{
    public class UpdateArticleCategoryCommandValidator : AbstractValidator<UpdateArticleCategoryCommand>
    {
        public UpdateArticleCategoryCommandValidator()
        {
            RuleFor(r => r.ArticleId).NotEmpty();
            RuleFor(r => r.CategoryId).NotEmpty();
        }
    }
}
