using AutoMapper;
using Core.Persistence.Paging;
using Website.Application.Features.ArticleMetas.Commands.CreateArticleMeta;
using Website.Application.Features.ArticleMetas.Commands.DeleteArticleMeta;
using Website.Application.Features.ArticleMetas.Commands.UpdateArticleMeta;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleMetas.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArticleMeta, ArticleMetaListDto>().ForMember(p=>p.ArticleName,
                                                                    opt=>opt.MapFrom(p=>p.Article.Title))
                                                                    .ReverseMap();
            CreateMap<ArticleMeta, ArticleMetaDto>().ForMember(x=>x.ArticleName,
                                                                 opt=>opt.MapFrom(x=>x.Article.Title))
                                                                 .ReverseMap();
            CreateMap<ArticleMeta, UpdatedArticleMetaDto>().ReverseMap();
            CreateMap<ArticleMeta, DeletedArticleMetaDto>().ReverseMap();
            CreateMap<ArticleMeta, CreatedArticleMetaDto>().ReverseMap();
            CreateMap<ArticleMeta, CreateArticleMetaCommand>().ReverseMap();
            CreateMap<ArticleMeta, UpdateArticleMetaCommand>().ReverseMap();
            CreateMap<ArticleMeta, DeleteArticleMetaCommand>().ReverseMap();
            CreateMap<IPaginate<ArticleMeta>, ArticleMetaListModel>().ReverseMap();
        }
    }
}
