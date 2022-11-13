using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class Tag : Entity
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

        public Tag()
        {
            ArticleTags = new HashSet<ArticleTag>();
        }

        public Tag(int id, string title, string metaTitle, string slug, string content) : this()
        {
            Id = id;
            Title = title;
            MetaTitle = metaTitle;
            Slug = slug;
            Content = content;
        }
    }
}
