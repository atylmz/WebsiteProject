using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;

namespace Website.Application.Services.ArticleService
{
    public interface IArticleService
    {
        public Task<Article> CreateArticle(Article article);
        public Task<Article> DeleteArticle(Article article);
        public Task<Article> UpdateArticle(Article article);
    }
}
