using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.OperationClaims.Dtos
{
    public class OperationClaimDto : BaseDto
    {
        public string Name { get; set; }
    }
}
