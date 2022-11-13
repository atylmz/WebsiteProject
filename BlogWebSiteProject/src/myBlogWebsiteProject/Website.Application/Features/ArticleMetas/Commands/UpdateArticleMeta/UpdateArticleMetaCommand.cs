﻿using AutoMapper;
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

namespace Website.Application.Features.ArticleMetas.Commands.UpdateArticleMeta
{
    public class UpdateArticleMetaCommand : IRequest<UpdatedArticleMetaDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public class UpdateArticleMetaCommandHandler : IRequestHandler<UpdateArticleMetaCommand, UpdatedArticleMetaDto>
        {
            private readonly IArticleMetaRepository _articleMetaRepository;
            private readonly IMapper _mapper;
            private readonly ArticleMetaBusinessRules _businessRules;

            public UpdateArticleMetaCommandHandler(IArticleMetaRepository articleMetaRepository, IMapper mapper, ArticleMetaBusinessRules businessRules)
            {
                _articleMetaRepository = articleMetaRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedArticleMetaDto> Handle(UpdateArticleMetaCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ArticleMetaShouldBeExistWhenUpdate(request.Id);
                await _businessRules.ArticleShouldBeExistWhenUpdate(request.ArticleId);

                ArticleMeta mappedArticleMeta = _mapper.Map<ArticleMeta>(request);
                ArticleMeta updatedArticleMeta = await _articleMetaRepository.UpdateAsync(mappedArticleMeta);
                UpdatedArticleMetaDto updatedArticleMetaDto = _mapper.Map<UpdatedArticleMetaDto>(updatedArticleMeta);

                return updatedArticleMetaDto;
            }
        }
    }
}
