using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class ArticleCategory : Entity
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }

        public ArticleCategory()
        {

        }

        public ArticleCategory(int id,int articleId, int categoryId)
        {
            Id = id;
            ArticleId = articleId;
            CategoryId = categoryId;
        }
    }
}
