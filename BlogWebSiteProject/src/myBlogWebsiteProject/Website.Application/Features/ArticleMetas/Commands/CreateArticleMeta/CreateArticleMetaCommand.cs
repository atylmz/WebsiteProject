using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleMetas.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.ArticleMetas.Commands.CreateArticleMeta
{
    public class CreateArticleMetaCommand : IRequest<CreatedArticleMetaDto>, ISecuredRequest
    {
        public int ArticleId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] { Admin, ArticleMetasAdd };

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
