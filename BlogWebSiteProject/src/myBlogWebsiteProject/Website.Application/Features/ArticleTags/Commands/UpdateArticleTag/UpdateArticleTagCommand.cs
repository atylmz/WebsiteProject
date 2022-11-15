using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Commands.UpdateArticleTag
{
    public class UpdateArticleTagCommand : IRequest<UpdatedArticleTagDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public class UpdateArticleTagCommandHandler : IRequestHandler<UpdateArticleTagCommand, UpdatedArticleTagDto>
        {
            private readonly IArticleTagRepository _articleTagRepository;
            private readonly IMapper _mapper;
            private readonly ArticleTagBusinessRules _articleTagBusinessRules;

            public UpdateArticleTagCommandHandler(IArticleTagRepository articleTagRepository, IMapper mapper, ArticleTagBusinessRules articleTagBusinessRules)
            {
                _articleTagRepository = articleTagRepository;
                _mapper = mapper;
                _articleTagBusinessRules = articleTagBusinessRules;
            }

            public async Task<UpdatedArticleTagDto> Handle(UpdateArticleTagCommand request, CancellationToken cancellationToken)
            {
                await _articleTagBusinessRules.ArticleTagShouldBeExistWhenUpdate(request.Id);
                await _articleTagBusinessRules.ArticleShouldBeExistWhenUpdate(request.ArticleId);
                await _articleTagBusinessRules.TagShouldBeExistWhenUpdate(request.TagId);

                ArticleTag mappedArticleTag = _mapper.Map<ArticleTag>(request);
                ArticleTag updatedArticleTag = await _articleTagRepository.UpdateAsync(mappedArticleTag);
                UpdatedArticleTagDto updatedArticleTagDto = _mapper.Map<UpdatedArticleTagDto>(updatedArticleTag);

                return updatedArticleTagDto;
            }
        }
    }
}
