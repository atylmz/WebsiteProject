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
using Website.Application.Features.ArticleTags.Models;
using Website.Application.Features.ArticleTags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Queries.GetListArticleTag
{
    public class GetListArticleTagQuery : IRequest<ArticleTagListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListArticleTagQueryHandler : IRequestHandler<GetListArticleTagQuery, ArticleTagListModel>
        {
            private readonly IArticleTagRepository _articleTagRepository;
            private readonly IMapper _mapper;

            public GetListArticleTagQueryHandler(IArticleTagRepository articleTagRepository, IMapper mapper)
            {
                _articleTagRepository = articleTagRepository;
                _mapper = mapper;
            }

            public async Task<ArticleTagListModel> Handle(GetListArticleTagQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ArticleTag> articleTags = await _articleTagRepository
                    .GetListAsync(size: request.PageRequest.PageSize,
                                  index: request.PageRequest.Page,
                                  include: x=>x.Include(y=>y.Article).Include(c=>c.Tag));

                ArticleTagListModel articleTagListModel = _mapper.Map<ArticleTagListModel>(articleTags);

                return articleTagListModel;
            }
        }
    }
}
