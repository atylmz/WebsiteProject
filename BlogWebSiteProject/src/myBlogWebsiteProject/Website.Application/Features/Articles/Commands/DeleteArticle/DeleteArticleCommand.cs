using AutoMapper;
using MediatR;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Rules;
using Website.Application.Services.ArticleService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Articles.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<DeletedArticleDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, ArticleDelete };

        public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, DeletedArticleDto>
        {
            private readonly IArticleService _articleService;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public DeleteArticleCommandHandler(IArticleService articleService, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleService = articleService;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<DeletedArticleDto> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
            {
                await _articleBusinessRules.ArticleShouldBeExistWhenDelete(request.Id);

                Article mappedArticle = _mapper.Map<Article>(request);
                Article deletedArticle = await _articleService.DeleteArticle(mappedArticle);
                DeletedArticleDto deletedArticleDto = _mapper.Map<DeletedArticleDto>(deletedArticle);

                return deletedArticleDto;
            }
        }
    }
}
