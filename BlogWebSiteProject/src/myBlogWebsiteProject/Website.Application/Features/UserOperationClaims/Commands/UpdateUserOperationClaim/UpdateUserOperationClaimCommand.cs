using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Website.Application.Features.UserOperationClaims.Dtos;
using Website.Application.Features.UserOperationClaims.Rules;
using Website.Application.Services.Repositories;
using static Website.Application.Features.UserOperationClaims.Constants.OperationClaims;
using static Website.Domain.Constants.OperationClaims;

namespace Website.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string[] Roles => new[] { Admin, UserOperationClaimUpdate };

        public class
            UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
                UpdatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                          IMapper mapper,
                                                          UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request,
                                                                   CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim updatedUserOperationClaim =
                    await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
                UpdatedUserOperationClaimDto updatedUserOperationClaimDto =
                    _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
                return updatedUserOperationClaimDto;
            }
        }
    }
}
