using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Website.Application.Features.Articles.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Articles.Rules
{
    public class ArticleBusinessRules : BaseBusinessRules
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;

        public ArticleBusinessRules(IArticleRepository articleRepository, IAuthorRepository authorRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
        }

        public async Task ArticleTitleShouldNotBeExistWhenCreate(string title)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Title == title, enableTracking: false);
            if (article is not null)
                throw new BusinessException(ArticleMessages.ArticleTitleAlreadyExists);
        }

        public async Task ArticleAuthorShouldBeExistWhenCreate(int authorId)
        {
            Author? author = await _authorRepository.GetAsync(x => x.Id == authorId, enableTracking: false);
            if (author is null)
                throw new BusinessException(ArticleMessages.AuthorDoesNotExist);
        }

        public async Task ArticleShouldBeExistsWhenCreateSub(int? parentId)
        {
            Article? article = await _articleRepository.GetAsync(x=>x.Id== parentId, enableTracking: false);
            if (article is null)
                throw new BusinessException(ArticleMessages.ArticleDoesNotExist);
        }

        public async Task ArticleCanOnlyHaveOneParent(int? parentId)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == parentId, enableTracking: false);
            if(article.Id != article.ParentId)
                throw new BusinessException(ArticleMessages.ParentArticleAlreadyHaveAnotherParent);
        }

        public async Task ArticleTitleShouldNotBeExistWhenUpdate(string title)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Title == title, enableTracking: false);
            if (article is not null)
                throw new BusinessException(ArticleMessages.ArticleTitleAlreadyExists);
        }

        public async Task ArticleShouldBeExistWhenUpdate(int id)
        {
            Article? article = await _articleRepository.GetAsync(x=>x.Id== id, enableTracking: false);
            if (article is null)
                throw new BusinessException(ArticleMessages.ArticleDoesNotExist);
        }

        public async Task ArticleShouldBeExistWhenDelete(int id)
        {
            Article? article = await _articleRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (article is null)
                throw new BusinessException(ArticleMessages.ArticleDoesNotExist);
        }

        public Task ArticleShouldBeExistWhenSelect(Article article)
        {
            if (article is null)
                throw new BusinessException(ArticleMessages.ArticleDoesNotExist);
            return Task.CompletedTask;
        }
        public async Task ArticleAuthorShouldBeExistWhenUpdate(int authorId)
        {
            Author? author = await _authorRepository.GetAsync(x => x.Id == authorId, enableTracking: false);
            if (author is null)
                throw new BusinessException(ArticleMessages.AuthorDoesNotExist);
        }
    }
}
