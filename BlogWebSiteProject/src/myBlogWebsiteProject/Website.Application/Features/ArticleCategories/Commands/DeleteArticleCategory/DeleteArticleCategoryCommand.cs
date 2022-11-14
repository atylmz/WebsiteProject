using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Commands.DeleteArticleCategory
{
    public class DeleteArticleCategoryCommand : IRequest<DeletedArticleCategoryDto>
    {
        public int Id { get; set; }

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
