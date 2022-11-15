using AutoMapper;
using MediatR;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Commands.DeleteArticleTag
{
    public class DeleteArticleTagCommand : IRequest<DeletedArticleTagDto>
    {
        public int Id { get; set; }

        public class DeleteArticleTagCommandHandler : IRequestHandler<DeleteArticleTagCommand, DeletedArticleTagDto>
        {
            private readonly IArticleTagRepository _articleTagRepository;
            private readonly IMapper _mapper;
            private readonly ArticleTagBusinessRules _articleTagBusinessRules;

            public DeleteArticleTagCommandHandler(IArticleTagRepository articleTagRepository, IMapper mapper, ArticleTagBusinessRules articleTagBusinessRules)
            {
                _articleTagRepository = articleTagRepository;
                _mapper = mapper;
                _articleTagBusinessRules = articleTagBusinessRules;
            }

            public async Task<DeletedArticleTagDto> Handle(DeleteArticleTagCommand request, CancellationToken cancellationToken)
            {
                await _articleTagBusinessRules.ArticleTagShouldBeExistWhenDelete(request.Id);

                ArticleTag mappedArticleTag = _mapper.Map<ArticleTag>(request);
                ArticleTag deletedArticleTag = await _articleTagRepository.DeleteAsync(mappedArticleTag);
                DeletedArticleTagDto deletedArticleTagDto = _mapper.Map<DeletedArticleTagDto>(deletedArticleTag);

                return deletedArticleTagDto;
            }
        }
    }
}
