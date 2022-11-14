using Core.Persistence.Repositories;

namespace Website.Domain.Entites
{
    public class Comment : Entity
    {
        public int ArticleId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

        public virtual Comment ParentComment { get; set; }
        public virtual Article Article { get; set; }

        public ICollection<Comment> ParentComments { get; set; }

        public Comment()
        {
            ParentComments = new HashSet<Comment>();
        }

        public Comment(int id,int articleId, int parentId, string title, bool published, DateTime? publishedAt, string content) : this()
        {
            Id = id;
            ArticleId = articleId;
            ParentId = parentId;
            Title = title;
            Published = published;
            PublishedAt = publishedAt;
            Content = content;
        }
    }
}
