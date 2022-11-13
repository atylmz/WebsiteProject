using Core.Persistence.Repositories;
using Core.Security.Entities;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, BaseDbContext>, IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
