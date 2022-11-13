using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Categories.Dtos;

namespace Website.Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
