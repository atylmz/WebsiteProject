using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;

namespace Website.Application.Services.CommentService
{
    public interface ICommentService
    {
        public Task<Comment> CreateComment(Comment comment);
        public Task<Comment> DeleteComment(Comment comment);
    }
}
