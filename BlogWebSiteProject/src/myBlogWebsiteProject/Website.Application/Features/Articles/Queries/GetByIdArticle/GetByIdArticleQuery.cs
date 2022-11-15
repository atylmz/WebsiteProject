using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Articles.Queries.GetByIdArticle
{
    public class GetByIdArticleQuery : IRequest<ArticleDto>
    {
        public int Id { get; set; }

        public class GetByIdArticleQueryHandler : IRequestHandler<GetByIdArticleQuery, ArticleDto>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;
            private readonly ArticleBusinessRules _articleBusinessRules;

            public GetByIdArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper, ArticleBusinessRules articleBusinessRules)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
                _articleBusinessRules = articleBusinessRules;
            }

            public async Task<ArticleDto> Handle(GetByIdArticleQuery request, CancellationToken cancellationToken)
            {
                Article? article = await _articleRepository
                    .GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Author.User));

                await _articleBusinessRules.ArticleShouldBeExistWhenSelect(article);

                ArticleDto articleDto = _mapper.Map<ArticleDto>(article);

                return articleDto;
            }
        }
    }
}
