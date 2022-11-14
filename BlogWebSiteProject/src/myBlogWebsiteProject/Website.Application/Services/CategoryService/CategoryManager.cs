using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Categories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Services.CategoryService
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            if (category.ParentId == 0)
                return await CreateMainCategory(category);
            else
                return await CreateSubCategory(category);
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            Category? deleteCategory = await _categoryRepository.GetAsync(x => x.Id == category.Id,enableTracking: false);
            
            if (deleteCategory.Id == deleteCategory.ParentId)
            {
                IList<Category> listOfCategories = await GetSubCategories(deleteCategory);
                if (listOfCategories.Count > 0)
                    foreach (var item in listOfCategories)
                        await _categoryRepository.DeleteAsync(item);
            }
            else
            {
                deleteCategory.ParentId = null;
                deleteCategory = await _categoryRepository.UpdateAsync(deleteCategory);
                deleteCategory = await _categoryRepository.DeleteAsync(deleteCategory);
            }
          
            return deleteCategory;
        }

        private async Task<IList<Category>> GetSubCategories(Category? deleteCategory)
        {
            var hasNext = true;
            IList<Category> subCategories = new List<Category>();
            while (hasNext)
            {
                IPaginate<Category> categories = await _categoryRepository
                    .GetListAsync(predicate: x => x.ParentId == deleteCategory.Id,
                                  size: 10, index: 0);
                foreach (var category in categories.Items)
                    subCategories.Add(category);
                hasNext = categories.HasNext;
            }
            return subCategories;
        }

        private async Task<Category> CreateSubCategory(Category category)
        {
            Category addedCategory = await _categoryRepository.AddAsync(category);
            return addedCategory;
        }

        private async Task<Category> CreateMainCategory(Category category)
        {
            category.ParentId = null;
            Category addedCategory = await _categoryRepository.AddAsync(category);
            category.ParentId = addedCategory.Id;
            Category updatedCategory = await _categoryRepository.UpdateAsync(category);
            return updatedCategory;
        }


    }
}
