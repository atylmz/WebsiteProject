using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class Category : Entity
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public virtual Category ParentCategory { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<Category> ParentCategories { get; set; }

        public Category()
        {
            ArticleCategories = new HashSet<ArticleCategory>();
            ParentCategories = new HashSet<Category>();
        }

        public Category(int id, int parentId, string title, string metaTitle, string slug, string content) : this()
        {
            Id = id;
            ParentId = parentId;
            Title = title;
            MetaTitle = metaTitle;
            Slug = slug;
            Content = content;
        }
    }
}
