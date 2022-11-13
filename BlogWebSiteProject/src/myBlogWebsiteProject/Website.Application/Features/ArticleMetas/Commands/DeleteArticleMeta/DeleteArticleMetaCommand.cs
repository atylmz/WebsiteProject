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

namespace Website.Application.Features.ArticleMetas.Commands.DeleteArticleMeta
{
    public class DeleteArticleMetaCommand : IRequest<DeletedArticleMetaDto>
    {
        public int Id { get; set; }

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
