using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Users.Dtos;

namespace Website.Application.Features.Users.Models
{
    public class UserListModel : BasePageableModel
    {
        public IList<UserListDto> Items { get; set; }
    }
}
