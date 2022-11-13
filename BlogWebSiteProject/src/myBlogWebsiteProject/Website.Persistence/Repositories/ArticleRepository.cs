using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using Website.Persistence.Contexts;

namespace Website.Persistence.Repositories
{
    public class ArticleRepository : EfRepositoryBase<Article, BaseDbContext>, IArticleRepository
    {
        public ArticleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
