using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleTags.Dtos
{
    public class ArticleTagDto : BaseDto
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public string ArticleTitle { get; set; }
        public string TagName { get; set; }
    }
}
