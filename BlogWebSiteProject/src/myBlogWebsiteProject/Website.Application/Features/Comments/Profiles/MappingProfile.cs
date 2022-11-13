using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>().ForMember(m => m.AticleTitle,
                p => p.MapFrom(c => c.Article.Title))
                .ReverseMap();
            CreateMap<Comment, CommentListDto>().ForMember(m => m.AticleTitle,
                p => p.MapFrom(c => c.Article.Title))
                .ReverseMap();
            CreateMap<Comment, CreatedCommentDto>().ReverseMap();
            CreateMap<Comment, UpdatedCommentDto>().ReverseMap();
            CreateMap<Comment, DeletedCommentDto>().ReverseMap();
        }
    }
}
