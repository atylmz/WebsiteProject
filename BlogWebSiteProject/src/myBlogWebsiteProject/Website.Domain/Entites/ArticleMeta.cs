using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class ArticleMeta : Entity
    {
        public int ArticleId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public virtual Article Article {get;set;}

        public ArticleMeta()
        {

        }

        public ArticleMeta(int id, string key, string content) : base(id)
        {
            Key = key;
            Content = content;
        }
    }
}
