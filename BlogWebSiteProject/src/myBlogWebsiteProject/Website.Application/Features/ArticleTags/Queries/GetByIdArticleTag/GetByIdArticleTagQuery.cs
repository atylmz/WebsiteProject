using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Queries.GetByIdArticleTag
{
    public class GetByIdArticleTagQuery : IRequest<ArticleTagDto>
    {
        public int Id { get; set; }

        public class GetByIdArticleTagQueryHandler : IRequestHandler<GetByIdArticleTagQuery, ArticleTagDto>
        {
            private readonly IArticleTagRepository _articleTagRepository;
            private readonly IMapper _mapper;
            private readonly ArticleTagBusinessRules _articleTagBusinessRules;

            public GetByIdArticleTagQueryHandler(IArticleTagRepository articleTagRepository, IMapper mapper, ArticleTagBusinessRules articleTagBusinessRules)
            {
                _articleTagRepository = articleTagRepository;
                _mapper = mapper;
                _articleTagBusinessRules = articleTagBusinessRules;
            }

            public async Task<ArticleTagDto> Handle(GetByIdArticleTagQuery request, CancellationToken cancellationToken)
            {
                ArticleTag? articleTag = await _articleTagRepository
                    .GetAsync(x => x.Id == request.Id,
                              include: p => p.Include(y => y.Article).Include(c => c.Tag));

                await _articleTagBusinessRules.ArticleTagShouldBeExistWhenSelect(articleTag);

                ArticleTagDto articleTagDto = _mapper.Map<ArticleTagDto>(articleTag);

                return articleTagDto;
            }
        }
    }
}
