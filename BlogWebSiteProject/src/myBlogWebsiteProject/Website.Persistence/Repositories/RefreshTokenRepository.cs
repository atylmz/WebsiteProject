using Core.Persistence.Repositories;
using Core.Security.Entities;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
