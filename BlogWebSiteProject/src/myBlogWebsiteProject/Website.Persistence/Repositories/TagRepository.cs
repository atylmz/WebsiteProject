using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class TagRepository : EfRepositoryBase<Tag, BaseDbContext>, ITagRepository
    {
        public TagRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
