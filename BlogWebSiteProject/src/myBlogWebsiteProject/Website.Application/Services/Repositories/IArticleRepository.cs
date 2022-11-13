using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;

namespace Website.Application.Services.Repositories
{
    public interface IArticleRepository : IAsyncRepository<Article>, IRepository<Article>
    {
    }
}
