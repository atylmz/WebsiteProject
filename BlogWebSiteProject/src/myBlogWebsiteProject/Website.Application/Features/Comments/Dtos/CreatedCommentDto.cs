using Core.Persistence.Repositories;

namespace Website.Application.Features.Comments.Dtos
{
    public class CreatedCommentDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
