using Core.Persistence.Repositories;
using Core.Security.Entities;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
