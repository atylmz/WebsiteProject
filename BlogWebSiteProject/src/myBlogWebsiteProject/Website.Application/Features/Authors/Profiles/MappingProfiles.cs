using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Authors.Commands.CreateAuthor;
using Website.Application.Features.Authors.Commands.DeleteAuthor;
using Website.Application.Features.Authors.Commands.UpdateAuthor;
using Website.Application.Features.Authors.Dtos;
using Website.Application.Features.Authors.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.Authors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>().ForMember(m => m.UserName,
                opt => opt.MapFrom(p => new string(p.User.FirstName + " " + p.User.LastName)))
                .ReverseMap();
            CreateMap<Author, AuthorListDto>().ForMember(m => m.UserName,
                opt => opt.MapFrom(p => new string(p.User.FirstName + " " + p.User.LastName)))
                .ReverseMap();
            CreateMap<Author, CreatedAuthorDto>().ReverseMap();
            CreateMap<Author, DeletedAuthorDto>().ReverseMap();
            CreateMap<Author, UpdatedAuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, DeleteAuthorCommand>().ReverseMap();
            CreateMap<IPaginate<Author>, AuthorListModel>().ReverseMap();
        }
    }
}
