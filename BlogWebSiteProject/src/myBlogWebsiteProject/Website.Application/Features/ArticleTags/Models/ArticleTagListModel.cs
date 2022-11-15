using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleTags.Dtos;

namespace Website.Application.Features.ArticleTags.Models
{
    public class ArticleTagListModel : BasePageableModel
    {
        public IList<ArticleTagListDto> Items { get; set; }
    }
}
