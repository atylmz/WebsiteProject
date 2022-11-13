using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.UserOperationClaims.Constants;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task UserOperationClaimIdShouldExistWhenSelected(int id)
        {
            UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(UserOperationClaimMessages.UserOperationClaimNotExists);
        }
    }
}
