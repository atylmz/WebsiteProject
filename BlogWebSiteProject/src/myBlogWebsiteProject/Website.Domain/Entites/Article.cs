using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class Article : Entity
    {
        public int AuthorId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool Published { get; set; }
        public string Content { get; set; }

        public virtual Author Author { get; set; }
        public virtual Article ParentArticle{ get; set; }

        public virtual ICollection<Article> ParentArticles { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
        public virtual ICollection<ArticleMeta> ArticleMetas { get; set; }

        public Article()
        {
            ParentArticles = new HashSet<Article>();
            ArticleCategories = new HashSet<ArticleCategory>();
            ArticleTags = new HashSet<ArticleTag>();
            ArticleMetas = new HashSet<ArticleMeta>();
        }

        public Article(int id, int authorId,
            int parentId, string title,
            string metaTitle, string slug,
            string summary, DateTime? publishedAt,
            bool published, string content)
            : this()
        {
            Id = id;
            AuthorId = authorId;
            ParentId = parentId;
            Title = title;
            MetaTitle = metaTitle;
            Slug = slug;
            Summary = summary;
            PublishedAt = publishedAt;
            Published = published;
            Content = content;
        }
    }
}
