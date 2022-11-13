using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Website.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Website.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Website.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Website.Application.Features.OperationClaims.Dtos;
using Website.Application.Features.OperationClaims.Models;

namespace Website.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        }
    }
}
