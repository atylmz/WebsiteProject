using Core.Persistence.Repositories;

namespace Website.Application.Features.ArticleTags.Dtos
{
    public class ArticleTagListDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public string ArticleTitle { get; set; }
        public string TagName { get; set; }
    }
}
