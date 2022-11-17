using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleMetas.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.ArticleMetas.Commands.DeleteArticleMeta
{
    public class DeleteArticleMetaCommand : IRequest<DeletedArticleMetaDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, ArticleMetasDelete };

        public class DeleteArticleMetaCommandHandler : IRequestHandler<DeleteArticleMetaCommand, DeletedArticleMetaDto>
        {
            private readonly IArticleMetaRepository _articleMetaRepository;
            private readonly IMapper _mapper;
            private readonly ArticleMetaBusinessRules _businessRules;

            public DeleteArticleMetaCommandHandler(IArticleMetaRepository articleMetaRepository, IMapper mapper, ArticleMetaBusinessRules businessRules)
            {
                _articleMetaRepository = articleMetaRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletedArticleMetaDto> Handle(DeleteArticleMetaCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ArticleMetaShouldBeExistWhenDelete(request.Id);

                ArticleMeta mappedArticleMeta = _mapper.Map<ArticleMeta>(request);
                ArticleMeta deletedArticleMeta = await _articleMetaRepository.DeleteAsync(mappedArticleMeta);
                DeletedArticleMetaDto deletedArticleMetaDto = _mapper.Map<DeletedArticleMetaDto>(deletedArticleMeta);

                return deletedArticleMetaDto;
            }
        }
    }
}
