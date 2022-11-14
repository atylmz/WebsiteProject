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
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Models;
using Website.Application.Features.Categories.Queries.GetListCategory;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Queries.GetListArticleCategory
{
    public class GetListArticleCategoryQuery : IRequest<ArticleCategoryListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListArticleQueryHandler : IRequestHandler<GetListArticleCategoryQuery, ArticleCategoryListModel>
        {
            private readonly IArticleCategoryRepository _articleCategoryRepository;
            private readonly IMapper _mapper;

            public GetListArticleQueryHandler(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
            {
                _articleCategoryRepository = articleCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ArticleCategoryListModel> Handle(GetListArticleCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ArticleCategory> articleCategories = await _articleCategoryRepository
                    .GetListAsync(size: request.PageRequest.PageSize,
                                  index: request.PageRequest.Page,
                                  include: x => x.Include(m => m.Article).Include(c => c.Category));

                ArticleCategoryListModel articleCategoryListModel = _mapper.Map<ArticleCategoryListModel>(articleCategories);

                return articleCategoryListModel;
            }
        }
    }
}
