namespace Website.Application.Features.Comments.Dtos
{
    public class UpdatedCommentDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
