using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class ArticleTag : Entity
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }

        public ArticleTag()
        {

        }

        public ArticleTag(int id, int articleId, int tagId) : this()
        {
            Id = id;
            ArticleId = articleId;
            TagId = tagId;
        }
    }

}
