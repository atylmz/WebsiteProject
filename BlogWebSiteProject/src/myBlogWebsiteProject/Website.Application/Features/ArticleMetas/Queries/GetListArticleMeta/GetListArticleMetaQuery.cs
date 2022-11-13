using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleMetas.Models;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleMetas.Queries.GetListArticleMeta
{
    public class GetListArticleMetaQuery : IRequest<ArticleMetaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListArticleMetaQueryHandler : IRequestHandler<GetListArticleMetaQuery, ArticleMetaListModel>
        {
            private readonly IArticleMetaRepository _articleMetaRepository;
            private readonly IMapper _mapper;

            public GetListArticleMetaQueryHandler(IArticleMetaRepository articleMetaRepository, IMapper mapper)
            {
                _articleMetaRepository = articleMetaRepository;
                _mapper = mapper;
            }

            public async Task<ArticleMetaListModel> Handle(GetListArticleMetaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ArticleMeta> articleMetas = await _articleMetaRepository
                    .GetListAsync(index: request.PageRequest.Page,
                                  size: request.PageRequest.PageSize,
                                  include: x => x.Include(p => p.Article));
                ArticleMetaListModel articleMetaListModel = _mapper.Map<ArticleMetaListModel>(articleMetas);

                return articleMetaListModel;
            }
        }
    }
}
