using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleMetas.Queries.GetByIdArticleMeta
{
    public class GetByIdArticleMetaQuery : IRequest<ArticleMetaDto>
    {
        public int Id { get; set; }

        public class GetByIdArticleMetaHandler : IRequestHandler<GetByIdArticleMetaQuery, ArticleMetaDto>
        {
            private readonly IArticleMetaRepository _articleMetaRepository;
            private readonly IMapper _mapper;
            private readonly ArticleMetaBusinessRules _businessRules;

            public GetByIdArticleMetaHandler(IArticleMetaRepository articleMetaRepository, IMapper mapper, ArticleMetaBusinessRules businessRules)
            {
                _articleMetaRepository = articleMetaRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<ArticleMetaDto> Handle(GetByIdArticleMetaQuery request, CancellationToken cancellationToken)
            {
                await _businessRules.ArticleMetaShouldBeExistWhenSelect(request.Id);

                ArticleMeta? articleMeta = await _articleMetaRepository
                    .GetAsync(x => x.Id == request.Id,
                                include: x=>x.Include(c=>c.Article));
                ArticleMetaDto articleMetaDto = _mapper.Map<ArticleMetaDto>(articleMeta);

                return articleMetaDto;
            }
        }
    }
}
