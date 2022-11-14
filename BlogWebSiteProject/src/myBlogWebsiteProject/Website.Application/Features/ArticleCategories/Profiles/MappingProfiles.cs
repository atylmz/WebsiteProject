using AutoMapper;
using Core.Persistence.Paging;
using Website.Application.Features.ArticleCategories.Commands.CreateArticleCategory;
using Website.Application.Features.ArticleCategories.Commands.UpdateArticleCategory;
using Website.Application.Features.ArticleCategories.Commands.DeleteArticleCategory;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.ArticleCategories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArticleCategory, ArticleCategoryDto>()
                .ForMember(m => m.ArticleTitle, c => c.MapFrom(x => x.Article.Title))
                .ForMember(m=>m.CategoryName, c=>c.MapFrom(x=>x.Category.Title))
                .ReverseMap();
            CreateMap<ArticleCategory, ArticleCategoryListDto>()
               .ForMember(m => m.ArticleTitle, c => c.MapFrom(x => x.Article.Title))
               .ForMember(m => m.CategoryName, c => c.MapFrom(x => x.Category.Title))
               .ReverseMap();
            CreateMap<ArticleCategory, CreatedArticleCategoryDto>().ReverseMap();
            CreateMap<ArticleCategory, UpdatedArticleCategoryDto>().ReverseMap();
            CreateMap<ArticleCategory, DeletedArticleCategoryDto>().ReverseMap();
            CreateMap<IPaginate<ArticleCategory>, ArticleCategoryListModel>().ReverseMap();
            CreateMap<ArticleCategory, CreateArticleCategoryCommand>().ReverseMap();
            CreateMap<ArticleCategory, UpdateArticleCategoryCommand>().ReverseMap();
            CreateMap<ArticleCategory, DeleteArticleCategoryCommand>().ReverseMap();
        }
    }
}
