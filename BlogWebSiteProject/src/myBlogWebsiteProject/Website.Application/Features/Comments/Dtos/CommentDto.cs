using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Comments.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string AticleTitle { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
