using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Auths.Dtos;

namespace Website.Application.Features.Auths.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RefreshToken, RevokedTokenDto>().ReverseMap();
        }
    }
}
