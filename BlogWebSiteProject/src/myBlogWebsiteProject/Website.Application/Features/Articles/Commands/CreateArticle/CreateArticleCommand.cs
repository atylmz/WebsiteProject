using AutoMapper;
using MediatR;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Rules;
using Website.Application.Services.ArticleService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Articles.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<CreatedArticleDto>, ISecuredRequest
    {
        public int AuthorId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool Published { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] {Admin, ArticleAdd };

        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreatedArticleDto>
        {
            private readonly IArticleService _articleService;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public CreateArticleCommandHandler(IArticleService articleService, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleService = articleService;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<CreatedArticleDto> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                await _articleBusinessRules.ArticleTitleShouldNotBeExistWhenCreate(request.Title);
                await _articleBusinessRules.ArticleAuthorShouldBeExistWhenCreate(request.AuthorId);
                if (request.ParentId != 0)
                {
                    await _articleBusinessRules.ArticleShouldBeExistsWhenCreateSub(request.ParentId);
                    await _articleBusinessRules.ArticleCanOnlyHaveOneParent(request.ParentId);
                }

                Article mappedArticle = _mapper.Map<Article>(request);
                Article createdArticle = await _articleService.CreateArticle(mappedArticle);
                CreatedArticleDto createdArticleDto = _mapper.Map<CreatedArticleDto>(createdArticle);

                return createdArticleDto;
            }
        }
    }
}
