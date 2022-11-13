using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Website.Application.Features.OperationClaims.Dtos;
using Website.Application.Features.OperationClaims.Rules;
using Website.Application.Services.Repositories;
using static Website.Application.Features.OperationClaims.Constants.OperationClaims;
using static Website.Domain.Constants.OperationClaims;

namespace Website.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { Admin, OperationClaimAdd };

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
                return createdOperationClaimDto;
            }
        }
    }
}
