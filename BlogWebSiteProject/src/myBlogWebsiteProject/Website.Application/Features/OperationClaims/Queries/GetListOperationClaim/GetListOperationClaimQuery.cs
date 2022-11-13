using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.OperationClaims.Models;
using Website.Application.Features.OperationClaims.Rules;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest{ get; set; }

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                                                                                                        size: request.PageRequest.PageSize);
                OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

                return mappedOperationClaimListModel;
            }
        }
    }
}
