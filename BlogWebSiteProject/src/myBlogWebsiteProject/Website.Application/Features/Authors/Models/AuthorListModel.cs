using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Authors.Dtos;

namespace Website.Application.Features.Authors.Models
{
    public class AuthorListModel
    {
        public IList<AuthorListDto> Items { get; set; }
    }
}
