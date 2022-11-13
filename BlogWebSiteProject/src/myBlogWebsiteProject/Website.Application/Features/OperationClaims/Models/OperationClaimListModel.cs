using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.OperationClaims.Dtos;

namespace Website.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel : BasePageableModel
    {
        public IList<OperationClaimListDto> Items { get; set; }
    }
}
