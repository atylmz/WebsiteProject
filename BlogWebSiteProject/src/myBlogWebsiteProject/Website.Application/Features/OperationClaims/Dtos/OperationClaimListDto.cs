using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.OperationClaims.Dtos
{
    public class OperationClaimListDto : BaseDto
    {
        public string Name { get; set; }
    }
}
