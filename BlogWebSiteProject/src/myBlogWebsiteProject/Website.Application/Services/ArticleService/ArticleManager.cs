using Core.Persistence.Paging;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Services.ArticleService
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> CreateArticle(Article article)
        {
            if (article.Published) article.PublishedAt = DateTime.UtcNow;
            else article.PublishedAt = null;

            if (article.ParentId == 0)
                return await CreateMainArticle(article);
            else
                return await CreateSubArticle(article);
        }

        public async Task<Article> DeleteArticle(Article article)
        {
            Article? deleteArticle = await _articleRepository.GetAsync(x => x.Id == article.Id, enableTracking: false);
            if (deleteArticle.Id == deleteArticle.ParentId)
            {
                IList<Article> listOfArticles = await GetSubArticles(deleteArticle);
                if (listOfArticles.Count > 0)
                    foreach (var item in listOfArticles)
                        await _articleRepository.DeleteAsync(item);
            }
            else
            {
                deleteArticle.ParentId = null;
                deleteArticle = await _articleRepository.UpdateAsync(deleteArticle);
                deleteArticle = await _articleRepository.DeleteAsync(deleteArticle);
            }
            return deleteArticle;
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            if(article.Published) article.PublishedAt = DateTime.UtcNow;
            Article updatedArticle = await _articleRepository.UpdateAsync(article);
            return updatedArticle;
        }

        private async Task<IList<Article>> GetSubArticles(Article deleteArticle)
        {
            var hasNext = true;
            IList<Article> subArticles = new List<Article>();
            while (hasNext)
            {
                IPaginate<Article> articles = await _articleRepository
                    .GetListAsync(predicate: x => x.ParentId == deleteArticle.Id,
                                  size: 10, index: 0);
                foreach (var article in articles.Items)
                    subArticles.Add(article);
                hasNext = articles.HasNext;
            }
            return subArticles;
        }

        private async Task<Article> CreateSubArticle(Article article)
        {

            Article createdArticle = await _articleRepository.AddAsync(article);
            return createdArticle;
        }

        private async Task<Article> CreateMainArticle(Article article)
        {
            article.ParentId = null;
            Article addedArticle = await _articleRepository.AddAsync(article);
            article.ParentId = addedArticle.Id;
            Article updatedArticle = await _articleRepository.UpdateAsync(article);
            return updatedArticle;
        }
    }
}
