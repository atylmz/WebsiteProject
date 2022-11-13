using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;

namespace Website.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<Category> CreateCategory(Category category);
        public Task<Category> DeleteCategory(Category category);
    }
}
