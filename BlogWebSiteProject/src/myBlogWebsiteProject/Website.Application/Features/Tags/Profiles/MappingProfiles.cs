using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Commands.CreateTag;
using Website.Application.Features.Tags.Commands.DeleteTag;
using Website.Application.Features.Tags.Commands.UpdateTag;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Features.Tags.Models;

namespace Website.Application.Features.Tags.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entites.Tag, CreateTagCommand>().ReverseMap();
            CreateMap<Domain.Entites.Tag, CreatedTagDto>().ReverseMap();
            CreateMap<Domain.Entites.Tag, DeletedTagDto>().ReverseMap();
            CreateMap<Domain.Entites.Tag, DeleteTagCommand>().ReverseMap();
            CreateMap<Domain.Entites.Tag, UpdatedTagDto>().ReverseMap();
            CreateMap<Domain.Entites.Tag, UpdateTagCommand>().ReverseMap();
            CreateMap<Domain.Entites.Tag, TagDto>().ReverseMap();
            CreateMap<Domain.Entites.Tag, TagListDto>().ReverseMap();
            CreateMap<IPaginate<Domain.Entites.Tag>, TagListModel>().ReverseMap();
        }
    }
}
