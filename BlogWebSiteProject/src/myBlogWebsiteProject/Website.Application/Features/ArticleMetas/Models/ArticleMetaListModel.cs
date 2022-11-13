using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleMetas.Dtos;

namespace Website.Application.Features.ArticleMetas.Models
{
    public class ArticleMetaListModel : BasePageableModel
    {
        public IList<ArticleMetaListDto> Items { get; set; }
    }
}
