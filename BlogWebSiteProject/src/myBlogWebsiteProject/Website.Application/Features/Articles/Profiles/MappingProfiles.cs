using AutoMapper;
using Core.Persistence.Paging;
using Website.Application.Features.Articles.Commands.CreateArticle;
using Website.Application.Features.Articles.Commands.DeleteArticle;
using Website.Application.Features.Articles.Commands.UpdateArticle;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.Articles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(m=>m.AuthorName, 
                f=>f.MapFrom(x=>new string($"{x.Author.User.FirstName} {x.Author.User.LastName}")))
                .ReverseMap();
            CreateMap<Article, ArticleListDto>()
                .ForMember(m => m.AuthorName,
                f =>f.MapFrom(x => new string($"{x.Author.User.FirstName} {x.Author.User.LastName}")))
                .ReverseMap();
            CreateMap<Article, CreatedArticleDto>().ReverseMap();
            CreateMap<Article, UpdatedArticleDto>().ReverseMap();
            CreateMap<Article, DeletedArticleDto>().ReverseMap();
            CreateMap<IPaginate<Article>, ArticleListModel>().ReverseMap();
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
            CreateMap<Article, UpdateArticleCommand>().ReverseMap();
            CreateMap<Article, DeleteArticleCommand>().ReverseMap();
        }
    }
}
