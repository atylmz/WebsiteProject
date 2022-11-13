using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;

namespace Website.Application.Features.Comments.Models
{
    public class CommentListModel
    {
        public IList<CommentListDto> Items { get; set; }
    }
}
