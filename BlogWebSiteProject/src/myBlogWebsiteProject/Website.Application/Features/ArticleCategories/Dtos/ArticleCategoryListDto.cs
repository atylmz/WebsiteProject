using Core.Persistence.Repositories;

namespace Website.Application.Features.ArticleCategories.Dtos
{
    public class ArticleCategoryListDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string ArticleTitle { get; set; }
        public string CategoryName { get; set; }
    }
}
