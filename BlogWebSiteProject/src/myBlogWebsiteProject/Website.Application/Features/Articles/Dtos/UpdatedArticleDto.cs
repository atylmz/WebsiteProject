using Core.Persistence.Repositories;

namespace Website.Application.Features.Articles.Dtos
{
    public class UpdatedArticleDto : BaseDto
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
    }
}
