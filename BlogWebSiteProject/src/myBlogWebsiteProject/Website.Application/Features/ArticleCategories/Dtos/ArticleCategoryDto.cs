using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleCategories.Dtos
{
    public class ArticleCategoryDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string ArticleTitle { get; set; }
        public string CategoryName { get; set; }
    }
}
