using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Domain.Entites
{
    public class Author : Entity
    {
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Author()
        {
            Articles = new HashSet<Article>();
        }

        public Author(int id,int userId, string description) : this()
        {
            Id = id;
            UserId = userId;
            Description = description;
        }
    }
}
