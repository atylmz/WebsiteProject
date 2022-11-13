using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class ArticleCategoryRepository : EfRepositoryBase<ArticleCategory, BaseDbContext>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
