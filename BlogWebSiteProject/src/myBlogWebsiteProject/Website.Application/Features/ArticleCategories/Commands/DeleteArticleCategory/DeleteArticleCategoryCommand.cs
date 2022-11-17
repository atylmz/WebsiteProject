using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleCategories.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.ArticleCategories.Commands.DeleteArticleCategory
{
    public class DeleteArticleCategoryCommand : IRequest<DeletedArticleCategoryDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, ArticleCategoryDelete };

        public class DeleteArticleCategoryCommandHandler : IRequestHandler<DeleteArticleCategoryCommand, DeletedArticleCategoryDto>
        {
            private readonly IArticleCategoryRepository _articleCategoryRepository;
            private readonly IMapper _mapper;
            private readonly ArticleCategoryBusinessRules _articleCategoryBusinessRules;

            public DeleteArticleCategoryCommandHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper, ArticleCategoryBusinessRules articleCategoryBusinessRules)
            {
                _articleCategoryRepository = articleCategoryRepository;
                _mapper = mapper;
                _articleCategoryBusinessRules = articleCategoryBusinessRules;
            }

            public async Task<DeletedArticleCategoryDto> Handle(DeleteArticleCategoryCommand request, CancellationToken cancellationToken)
            {
                await _articleCategoryBusinessRules.ArticleCategoryShouldBeExistWhenDelete(request.Id);

                ArticleCategory mappedArticleCategory = _mapper.Map<ArticleCategory>(request);
                ArticleCategory deletedArticleCategory = await _articleCategoryRepository.DeleteAsync(mappedArticleCategory);
                DeletedArticleCategoryDto deletedArticleCategoryDto = _mapper.Map<DeletedArticleCategoryDto>(deletedArticleCategory);

                return deletedArticleCategoryDto;
            }
        }
    }
}
