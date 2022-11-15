using Core.Persistence.Repositories;

namespace Website.Application.Features.ArticleCategories.Dtos
{
    public class CreatedArticleCategoryDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
    }
}
