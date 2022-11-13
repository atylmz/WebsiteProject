using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.UserOperationClaims.Dtos;

namespace Website.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
