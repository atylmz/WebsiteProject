using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Dtos;

namespace Website.Application.Features.Tags.Models
{
    public class TagListModel : BasePageableModel
    {
        public IList<TagListDto> Items { get; set; }
    }
}
