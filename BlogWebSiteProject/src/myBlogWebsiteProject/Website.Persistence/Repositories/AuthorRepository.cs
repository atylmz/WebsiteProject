using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class AuthorRepository : EfRepositoryBase<Author, BaseDbContext>, IAuthorRepository
    {
        public AuthorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
