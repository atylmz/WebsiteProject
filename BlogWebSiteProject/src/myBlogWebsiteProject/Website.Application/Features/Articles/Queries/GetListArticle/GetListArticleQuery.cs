using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Website.Application.Features.Articles.Models;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Articles.Queries.GetListArticle
{
    public class GetListArticleQuery : IRequest<ArticleListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListArticleQueryHandler : IRequestHandler<GetListArticleQuery, ArticleListModel>
        {
            private readonly IArticleRepository _articleRepository;
            private readonly IMapper _mapper;

            public GetListArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
            {
                _articleRepository = articleRepository;
                _mapper = mapper;
            }

            public async Task<ArticleListModel> Handle(GetListArticleQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Article> articles = await _articleRepository
                    .GetListAsync(size: request.PageRequest.PageSize,
                                  index: request.PageRequest.Page,
                                  include: x=>x.Include(i=>i.Author.User));
                ArticleListModel articleListModel = _mapper.Map<ArticleListModel>(articles);

                return articleListModel;
            }
        }
    }
}
