using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, BaseDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
