using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleCategories.Commands.CreateArticleCategory
{
    public class CreateArticleCategoryCommandValidator : AbstractValidator<CreateArticleCategoryCommand>
    {
        public CreateArticleCategoryCommandValidator()
        {
            RuleFor(r=>r.ArticleId).NotEmpty();
            RuleFor(r=>r.CategoryId).NotEmpty();
        }
    }
}
