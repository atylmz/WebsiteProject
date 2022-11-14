using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Commands.UpdateArticleCategory
{
    public class UpdateArticleCategoryCommand : IRequest<UpdatedArticleCategoryDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        public class UpdateArticleCategoryCommandHandler : IRequestHandler<UpdateArticleCategoryCommand, UpdatedArticleCategoryDto>
        {
            private readonly IArticleCategoryRepository _articleCategoryRepository;
            private readonly IMapper _mapper;
            private readonly ArticleCategoryBusinessRules _articleCategoryBusinessRules;

            public UpdateArticleCategoryCommandHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper, ArticleCategoryBusinessRules articleCategoryBusinessRules)
            {
                _articleCategoryRepository = articleCategoryRepository;
                _mapper = mapper;
                _articleCategoryBusinessRules = articleCategoryBusinessRules;
            }

            public async Task<UpdatedArticleCategoryDto> Handle(UpdateArticleCategoryCommand request, CancellationToken cancellationToken)
            {
                await _articleCategoryBusinessRules.CategoryShouldBeExistWhenUpdate(request.CategoryId);
                await _articleCategoryBusinessRules.ArticleShouldBeExistWhenUpdate(request.ArticleId);
                await _articleCategoryBusinessRules.ArticleCategoryShouldBeExistWhenUpdate(request.Id);

                ArticleCategory mappedArticleCategory = _mapper.Map<ArticleCategory>(request);
                ArticleCategory createdArticleCategory = await _articleCategoryRepository.UpdateAsync(mappedArticleCategory);
                UpdatedArticleCategoryDto updatedArticleCategoryDto = _mapper.Map<UpdatedArticleCategoryDto>(createdArticleCategory);

                return updatedArticleCategoryDto;
            }
        }
    }
}
