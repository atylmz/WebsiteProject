using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleCategories.Constants.OperationClaims;

namespace Website.Application.Features.ArticleCategories.Commands.CreateArticleCategory
{
    public class CreateArticleCategoryCommand : IRequest<CreatedArticleCategoryDto>, ISecuredRequest
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        public string[] Roles => new[] {Admin, ArticleCategoryAdd};

        public class CreateArticleCategoryCommandHandler : IRequestHandler<CreateArticleCategoryCommand, CreatedArticleCategoryDto>
        {
            private readonly IArticleCategoryRepository _articleCategoryRepository;
            private readonly IMapper _mapper;
            private readonly ArticleCategoryBusinessRules _articleCategoryBusinessRules;

            public CreateArticleCategoryCommandHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper, ArticleCategoryBusinessRules articleCategoryBusinessRules)
            {
                _articleCategoryRepository = articleCategoryRepository;
                _mapper = mapper;
                _articleCategoryBusinessRules = articleCategoryBusinessRules;
            }

            public async Task<CreatedArticleCategoryDto> Handle(CreateArticleCategoryCommand request, CancellationToken cancellationToken)
            {
                await _articleCategoryBusinessRules.ArticleShouldBeExistWhenCreate(request.ArticleId);
                await _articleCategoryBusinessRules.CategoryShouldBeExistWhenCreate(request.CategoryId);

                ArticleCategory mappedArticleCategory = _mapper.Map<ArticleCategory>(request);
                ArticleCategory createdArticleCategory = await _articleCategoryRepository.AddAsync(mappedArticleCategory);
                CreatedArticleCategoryDto createdArticleCategoryDto = _mapper.Map<CreatedArticleCategoryDto>(createdArticleCategory);

                return createdArticleCategoryDto;
            }
        }
    }
}
