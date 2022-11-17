using AutoMapper;
using MediatR;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Rules;
using Website.Application.Services.ArticleService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Articles.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<UpdatedArticleDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool Published { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] { Admin, ArticleUpdate };

        public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, UpdatedArticleDto>
        {
            private readonly IArticleService _articleService;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public UpdateArticleCommandHandler(IArticleService articleService, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleService = articleService;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<UpdatedArticleDto> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
            {
                await _articleBusinessRules.ArticleTitleShouldNotBeExistWhenUpdate(request.Title);
                await _articleBusinessRules.ArticleShouldBeExistWhenUpdate(request.Id);
                await _articleBusinessRules.ArticleAuthorShouldBeExistWhenUpdate(request.AuthorId);

                Article mappedArticle = _mapper.Map<Article>(request);
                Article updatedArticle = await _articleService.UpdateArticle(mappedArticle);
                UpdatedArticleDto updatedArticleDto = _mapper.Map<UpdatedArticleDto>(updatedArticle);

                return updatedArticleDto;
            }
        }
    }
}
