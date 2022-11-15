using Core.Persistence.Repositories;

namespace Website.Application.Features.Categories.Dtos
{
    public class CategoryListDto : BaseDto
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
    }
}
