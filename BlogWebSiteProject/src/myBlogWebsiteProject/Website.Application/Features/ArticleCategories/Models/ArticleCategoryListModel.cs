using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleCategories.Dtos;

namespace Website.Application.Features.ArticleCategories.Models
{
    public class ArticleCategoryListModel : BasePageableModel
    {
        public IList<ArticleCategoryListDto> Items { get; set; }
    }
}
