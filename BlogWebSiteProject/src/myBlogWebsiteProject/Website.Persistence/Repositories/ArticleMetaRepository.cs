using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class ArticleMetaRepository : EfRepositoryBase<ArticleMeta, BaseDbContext>, IArticleMetaRepository
    {
        public ArticleMetaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
