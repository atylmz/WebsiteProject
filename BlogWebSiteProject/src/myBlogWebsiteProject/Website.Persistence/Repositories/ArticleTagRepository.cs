using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class ArticleTagRepository : EfRepositoryBase<ArticleTag, BaseDbContext>, IArticleTagRepository
    {
        public ArticleTagRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
