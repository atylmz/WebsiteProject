using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.OperationClaims.Constants;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimIdShouldExistWhenSelected(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException(OperationClaimMessages.OperationClaimNotExists);
        }
    }
}
