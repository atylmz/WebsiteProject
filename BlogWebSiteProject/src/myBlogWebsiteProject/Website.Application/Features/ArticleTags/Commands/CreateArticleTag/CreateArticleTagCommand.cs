using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleTags.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.ArticleTags.Commands.CreateArticleTag
{
    public class CreateArticleTagCommand : IRequest<CreatedArticleTagDto>, ISecuredRequest
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public string[] Roles => new[] { Admin, ArticleTagAdd };

        public class CreateArticleTagCommandHandler : IRequestHandler<CreateArticleTagCommand, CreatedArticleTagDto>
        {
            private readonly IArticleTagRepository _articleTagRepository;
            private readonly IMapper _mapper;
            private readonly ArticleTagBusinessRules _articleTagBusinessRules;

            public CreateArticleTagCommandHandler(IArticleTagRepository articleTagRepository, IMapper mapper, ArticleTagBusinessRules articleTagBusinessRules)
            {
                _articleTagRepository = articleTagRepository;
                _mapper = mapper;
                _articleTagBusinessRules = articleTagBusinessRules;
            }

            public async Task<CreatedArticleTagDto> Handle(CreateArticleTagCommand request, CancellationToken cancellationToken)
            {
                await _articleTagBusinessRules.ArticleShouldBeExistWhenCreate(request.ArticleId);
                await _articleTagBusinessRules.TagShouldBeExistWhenCreate(request.TagId);

                ArticleTag mappedArticleTag = _mapper.Map<ArticleTag>(request);
                ArticleTag createdArticleTag = await _articleTagRepository.AddAsync(mappedArticleTag);
                CreatedArticleTagDto createdArticleTagDto = _mapper.Map<CreatedArticleTagDto>(createdArticleTag);

                return createdArticleTagDto;
            }
        }
    }
}
