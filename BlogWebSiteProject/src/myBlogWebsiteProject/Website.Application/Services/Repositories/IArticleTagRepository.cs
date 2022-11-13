using Core.Persistence.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Services.Repositories
{
    public interface IArticleTagRepository : IAsyncRepository<ArticleTag>, IRepository<ArticleTag>
    {
    }
}
