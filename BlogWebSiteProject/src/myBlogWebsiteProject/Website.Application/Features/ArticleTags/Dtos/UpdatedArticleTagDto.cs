using Core.Persistence.Repositories;

namespace Website.Application.Features.ArticleTags.Dtos
{
    public class UpdatedArticleTagDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
    }
}
