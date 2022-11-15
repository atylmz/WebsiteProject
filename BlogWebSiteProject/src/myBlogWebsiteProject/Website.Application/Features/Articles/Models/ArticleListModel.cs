using Core.Persistence.Paging;
using Website.Application.Features.Articles.Dtos;

namespace Website.Application.Features.Articles.Models
{
    public class ArticleListModel : BasePageableModel
    {
        public IList<ArticleListDto> Items { get; set; }
    }
}
