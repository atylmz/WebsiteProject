using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.ArticleTags.Commands.CreateArticleTag;
using Website.Application.Features.ArticleTags.Commands.DeleteArticleTag;
using Website.Application.Features.ArticleTags.Commands.UpdateArticleTag;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleTags.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArticleTag, ArticleTagDto>()
                .ForMember(x => x.ArticleTitle, x => x.MapFrom(x => x.Article.Title))
                .ForMember(y => y.TagName, y => y.MapFrom(y => y.Tag.Title))
                .ReverseMap();
            CreateMap<ArticleTag, ArticleTagListDto>()
               .ForMember(x => x.ArticleTitle, x => x.MapFrom(x => x.Article.Title))
               .ForMember(y => y.TagName, y => y.MapFrom(y => y.Tag.Title))
               .ReverseMap();
            CreateMap<ArticleTag, CreatedArticleTagDto>().ReverseMap();
            CreateMap<ArticleTag, UpdatedArticleTagDto>().ReverseMap();
            CreateMap<ArticleTag, DeletedArticleTagDto>().ReverseMap();
            CreateMap<IPaginate<ArticleTag>, ArticleTagListModel>().ReverseMap();
            CreateMap<ArticleTag, CreateArticleTagCommand>().ReverseMap();
            CreateMap<ArticleTag, UpdateArticleTagCommand>().ReverseMap();
            CreateMap<ArticleTag, DeleteArticleTagCommand>().ReverseMap();
        }
    }
}
