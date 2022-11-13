using Core.Persistence.Repositories;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class CommentRepository : EfRepositoryBase<Comment, BaseDbContext>, ICommentRepository
    {
        public CommentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
