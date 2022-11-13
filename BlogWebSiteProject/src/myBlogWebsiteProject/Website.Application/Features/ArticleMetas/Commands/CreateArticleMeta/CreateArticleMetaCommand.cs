using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleMetas.Commands.CreateArticleMeta
{
    public class CreateArticleMetaCommand : IRequest<CreatedArticleMetaDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleMetaCommand, CreatedArticleMetaDto>
        {
            private readonly IArticleMetaRepository _articleMetaRepository;
            private readonly IMapper _mapper;
            private readonly ArticleMetaBusinessRules _businessRules;

            public CreateArticleCommandHandler(IArticleMetaRepository articleMetaRepository, IMapper mapper, ArticleMetaBusinessRules businessRules)
            {
                _articleMetaRepository = articleMetaRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedArticleMetaDto> Handle(CreateArticleMetaCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ArticleShouldBeExistWhenInsert(request.ArticleId);

                ArticleMeta mappedArticleMeta = _mapper.Map<ArticleMeta>(request);
                ArticleMeta createdArticleMeta = await _articleMetaRepository.AddAsync(mappedArticleMeta);
                CreatedArticleMetaDto createdArticleMetaDto = _mapper.Map<CreatedArticleMetaDto>(createdArticleMeta);

                return createdArticleMetaDto;
            }
        }
    }
}
