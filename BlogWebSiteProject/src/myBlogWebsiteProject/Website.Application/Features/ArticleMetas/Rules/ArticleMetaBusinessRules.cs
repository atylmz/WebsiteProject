using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleMetas.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleMetas.Rules
{
    public class ArticleMetaBusinessRules : BaseBusinessRules
    {
        private readonly IArticleMetaRepository _articleMetaRepository;
        private readonly IArticleRepository _articleRepository;

        public async Task ArticleShouldBeExistWhenInsert(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId);
            if (article is null)
                throw new BusinessException(ArticleMetaMessages.ArticleDoesNotExist);
        }

        public async Task ArticleShouldBeExistWhenUpdate(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId);
            if (article is null)
                throw new BusinessException(ArticleMetaMessages.ArticleDoesNotExist);
        }

        public async Task ArticleMetaShouldBeExistWhenUpdate(int id)
        {
            ArticleMeta? articleMeta = await _articleMetaRepository.GetAsync(x => x.Id == id);
            if (articleMeta is null)
                throw new BusinessException(ArticleMetaMessages.ArticleMetaIsNotExist);
        }

        public async Task ArticleMetaShouldBeExistWhenDelete(int id)
        {
            ArticleMeta? articleMeta = await _articleMetaRepository.GetAsync(x => x.Id == id);
            if (articleMeta is null)
                throw new BusinessException(ArticleMetaMessages.ArticleMetaIsNotExist);
        }

        public async Task ArticleMetaShouldBeExistWhenSelect(int id)
        {
            ArticleMeta? articleMeta = await _articleMetaRepository.GetAsync(x => x.Id == id);
            if (articleMeta is null)
                throw new BusinessException(ArticleMetaMessages.ArticleMetaIsNotExist);
        }
    }
}
