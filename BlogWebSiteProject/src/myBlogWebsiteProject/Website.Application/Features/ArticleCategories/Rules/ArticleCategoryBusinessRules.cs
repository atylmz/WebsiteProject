using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Website.Application.Features.ArticleCategories.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Rules
{
    public class ArticleCategoryBusinessRules : BaseBusinessRules
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryBusinessRules(IArticleRepository articleRepository, ICategoryRepository categoryRepository, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public async Task ArticleShouldBeExistWhenCreate(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId, enableTracking: false);
            if (article == null)
                throw new BusinessException(ArticleCategoryMessages.ArticleDoesNotExist);
        }

        public async Task CategoryShouldBeExistWhenCreate(int categoryId)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == categoryId, enableTracking: false);
            if (category is null)
                throw new BusinessException(ArticleCategoryMessages.CategoryDoesNotExist);
        }
        public async Task ArticleShouldBeExistWhenUpdate(int articleId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == articleId, enableTracking: false);
            if (article == null)
                throw new BusinessException(ArticleCategoryMessages.ArticleDoesNotExist);
        }

        public async Task CategoryShouldBeExistWhenUpdate(int categoryId)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == categoryId, enableTracking: false);
            if (category is null)
                throw new BusinessException(ArticleCategoryMessages.CategoryDoesNotExist);
        }

        public async Task ArticleCategoryShouldBeExistWhenUpdate(int id)
        {
            ArticleCategory? articleCategory = await _articleCategoryRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (articleCategory is null)
                throw new BusinessException(ArticleCategoryMessages.ArticleCategoryDoesNotExist);
        }

        public async Task ArticleCategoryShouldBeExistWhenDelete(int id)
        {
            ArticleCategory? articleCategory = await _articleCategoryRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (articleCategory is null)
                throw new BusinessException(ArticleCategoryMessages.ArticleCategoryDoesNotExist);
        }

        public Task ArticleCategoryShouldBeExistWhenSelect(ArticleCategory articleCategory)
        {
            if (articleCategory is null)
                throw new BusinessException(ArticleCategoryMessages.ArticleCategoryDoesNotExist);
            return Task.CompletedTask;
        }
    }
}
