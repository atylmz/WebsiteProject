using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Website.Application.Features.ArticleTags.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Rules
{
    public class ArticleTagBusinessRules : BaseBusinessRules
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleTagRepository _articleTagRepository;
        private readonly ITagRepository _tagRepository;

        public ArticleTagBusinessRules(IArticleRepository articleRepository, IArticleTagRepository articleTagRepository, ITagRepository tagRepository)
        {
            _articleRepository = articleRepository;
            _articleTagRepository = articleTagRepository;
            _tagRepository = tagRepository;
        }

        public async Task ArticleShouldBeExistWhenCreate(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId, enableTracking: false);
            if (article == null)
                throw new BusinessException(ArticleTagMessages.ArticleDoesNotExist);
        }

        public async Task TagShouldBeExistWhenCreate(int tagId)
        {
            Tag? tag = await _tagRepository.GetAsync(x => x.Id == tagId, enableTracking: false);
            if (tag is null)
                throw new BusinessException(ArticleTagMessages.TagDoesNotExist);
        }

        public async Task ArticleShouldBeExistWhenUpdate(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId, enableTracking: false);
            if (article == null)
                throw new BusinessException(ArticleTagMessages.ArticleDoesNotExist);
        }

        public async Task TagShouldBeExistWhenUpdate(int tagId)
        {
            Tag? tag = await _tagRepository.GetAsync(x => x.Id == tagId, enableTracking: false);
            if (tag is null)
                throw new BusinessException(ArticleTagMessages.TagDoesNotExist);
        }

        public async Task ArticleTagShouldBeExistWhenUpdate(int id)
        {
            ArticleTag? articleTag = await _articleTagRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (articleTag is null)
                throw new BusinessException(ArticleTagMessages.ArticleTagDoesNoExist);
        }

        public async Task ArticleTagShouldBeExistWhenDelete(int id)
        {
            ArticleTag? articleTag = await _articleTagRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (articleTag is null)
                throw new BusinessException(ArticleTagMessages.ArticleTagDoesNoExist);
        }

        public Task ArticleTagShouldBeExistWhenSelect(ArticleTag articleTag)
        {
            if (articleTag is null)
                throw new BusinessException(ArticleTagMessages.ArticleTagDoesNoExist);
            return Task.CompletedTask;
        }

    }
}
