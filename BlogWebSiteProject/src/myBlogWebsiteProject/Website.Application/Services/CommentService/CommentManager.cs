using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Services.CommentService
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            if (comment.ParentId == 0)
                return await CreateMainComment(comment);
            else
                return await CreateSubComment(comment);
        }

        public async Task<Comment> DeleteComment(Category comment)
        {
            Comment? deleteComment = await _commentRepository.GetAsync(x => x.Id == comment.Id);
            return null;
        }

        private async Task<Comment> CreateSubComment(Comment comment)
        {
            Comment createdComment = await _commentRepository.AddAsync(comment);
            return createdComment;
        }

        private async Task<Comment> CreateMainComment(Comment comment)
        {
            comment.ParentId = null;
            Comment createdComment = await _commentRepository.AddAsync(comment);
            comment.ParentId = comment.Id;
            Comment updatedComment = await _commentRepository.UpdateAsync(comment);
            return updatedComment;
        }
    }
}
