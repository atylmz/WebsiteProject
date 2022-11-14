using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Queries.GetByIdArticleCategory
{
    public class GetByIdArticleCategoryQuery : IRequest<ArticleCategoryDto>
    {
        public int Id { get; set; }

        public class GetByIdArticleCategoryQueryHandler : IRequestHandler<GetByIdArticleCategoryQuery, ArticleCategoryDto>
        {
            private readonly IArticleCategoryRepository _articleCategoryRepository;
            private readonly IMapper _mapper;
            private readonly ArticleCategoryBusinessRules _articleCategoryBusinessRules;

            public GetByIdArticleCategoryQueryHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper, ArticleCategoryBusinessRules articleCategoryBusinessRules)
            {
                _articleCategoryRepository = articleCategoryRepository;
                _mapper = mapper;
                _articleCategoryBusinessRules = articleCategoryBusinessRules;
            }

            public async Task<ArticleCategoryDto> Handle(GetByIdArticleCategoryQuery request, CancellationToken cancellationToken)
            {
                ArticleCategory? articleCategory = await _articleCategoryRepository
                    .GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Category).Include(x => x.Article));

                await _articleCategoryBusinessRules.ArticleCategoryShouldBeExistWhenSelect(articleCategory);

                ArticleCategoryDto articleCategoryDto = _mapper.Map<ArticleCategoryDto>(articleCategory);

                return articleCategoryDto;
            }
        }
    }
}
