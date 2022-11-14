using Core.Persistence.Paging;
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
            if (comment.Published) comment.PublishedAt = DateTime.UtcNow;

            if (comment.ParentId == 0)
                return await CreateMainComment(comment);
            else
                return await CreateSubComment(comment);
        }

        public async Task<Comment> DeleteComment(Comment comment)
        {
            Comment? deleteComment = await _commentRepository.GetAsync(x => x.Id == comment.Id, enableTracking: false);
            if(deleteComment.Id == deleteComment.ParentId)
            {
                IList<Comment> listOfComments = await GetSubComments(deleteComment);
                if (listOfComments.Count > 0)
                    foreach (var item in listOfComments)
                        await _commentRepository.DeleteAsync(item);
            }
            else
            {
                deleteComment.ParentId = null;
                deleteComment = await _commentRepository.UpdateAsync(deleteComment);
                deleteComment = await _commentRepository.DeleteAsync(deleteComment);
            }
            return deleteComment;
        }

        private async Task<IList<Comment>> GetSubComments(Comment deleteComment)
        {
            var hasNext = true;
            IList<Comment> subComments = new List<Comment>();
            while (hasNext)
            {
                IPaginate<Comment> comments = await _commentRepository
                    .GetListAsync(predicate: x => x.ParentId == deleteComment.Id,
                                  size: 10, index: 0);
                foreach (var category in comments.Items)
                    subComments.Add(category);
                hasNext = comments.HasNext;
            }
            return subComments;
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
            comment.ParentId = createdComment.Id;
            Comment updatedComment = await _commentRepository.UpdateAsync(comment);
            return updatedComment;
        }
    }
}
