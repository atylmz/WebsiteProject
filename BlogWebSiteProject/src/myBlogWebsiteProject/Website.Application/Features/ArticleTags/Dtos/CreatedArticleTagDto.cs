using Core.Persistence.Repositories;

namespace Website.Application.Features.ArticleTags.Dtos
{
    public class CreatedArticleTagDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
    }
}
