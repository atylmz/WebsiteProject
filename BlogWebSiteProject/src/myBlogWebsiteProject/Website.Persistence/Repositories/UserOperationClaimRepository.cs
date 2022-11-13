using Core.Persistence.Repositories;
using Core.Security.Entities;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
