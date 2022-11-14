using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Categories.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules
    {
        ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryShouldBeExistWhenInsertSubCategory(int? parentId)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == parentId);
            if (category == null)
                throw new BusinessException(CategoryMessages.CategoryDoesNotExist);
        }

        public async Task CategoryTitleShouldNotBeExist(string title)
        {
            var category = await _categoryRepository.GetAsync(x => x.Title == title);
            if (category is not null)
                throw new BusinessException(CategoryMessages.CategoryTitleExists);
        }

        public async Task CategoryShouldBeExistWhenUpdate(int id)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == id);
            if (category is null)
                throw new BusinessException(CategoryMessages.CategoryDoesNotExist);
        }

        public async Task CategoryShouldBeExistWhenDelete(int id)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (category is null)
                throw new BusinessException(CategoryMessages.CategoryDoesNotExist);
        }
        public Task CategoryShouldBeExistWhenDelete(Category? category)
        {
           if(category == null)
                throw new BusinessException(CategoryMessages.CategoryDoesNotExist);
            return Task.CompletedTask;
        }
    }
}
