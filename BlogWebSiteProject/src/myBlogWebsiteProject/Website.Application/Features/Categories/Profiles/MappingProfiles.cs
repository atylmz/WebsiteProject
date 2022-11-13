using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Categories.Commands.CreateCategory;
using Website.Application.Features.Categories.Commands.DeleteCategory;
using Website.Application.Features.Categories.Commands.UpdateCategory;
using Website.Application.Features.Categories.Dtos;
using Website.Application.Features.Categories.Models;
using Website.Domain.Entites;

namespace Website.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
            CreateMap<Category, DeletedCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
        }
    }
}
