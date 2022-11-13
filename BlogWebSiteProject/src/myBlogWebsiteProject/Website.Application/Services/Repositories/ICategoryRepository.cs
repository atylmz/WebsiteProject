using Core.Persistence.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Services.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>, IRepository<Category>
    {
    }
}
