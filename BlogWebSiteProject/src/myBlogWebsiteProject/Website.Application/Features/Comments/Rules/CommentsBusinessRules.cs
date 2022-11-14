using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Website.Application.Features.Comments.Constants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Rules
{
    public class CommentsBusinessRules : BaseBusinessRules
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsBusinessRules(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task CommentShouldBeExistWhenSubCommentCreate(int parentId)
        {
            Comment? comment = await _commentRepository.GetAsync(x=>x.Id== parentId, enableTracking: false);
            if (comment == null)
                throw new BusinessException(CommentMessages.CommentDoesNotExist);
        }

        public async Task SubCommentCanHaveOnlyOneParent(int parentId)
        {
            Comment? comment = await _commentRepository.GetAsync(x => x.Id == parentId, enableTracking: false);
            if (comment.Id != comment.ParentId)
                throw new BusinessException(CommentMessages.CommentCantHaveMultipleParent);
        }

        public async Task CommentShouldBeExistWhenUpdate(int Id)
        {
            Comment? comment = await _commentRepository.GetAsync(x => x.Id == Id, enableTracking: false);
            if (comment == null)
                throw new BusinessException(CommentMessages.CommentDoesNotExist);
        }

        public async Task CommentShouldBeExistWhenDelete(int Id)
        {
            Comment? comment = await _commentRepository.GetAsync(x => x.Id == Id, enableTracking: false);
            if (comment == null)
                throw new BusinessException(CommentMessages.CommentDoesNotExist);
        }

        public Task CommentShouldBeExistWhenSelect(Comment comment)
        {
            if (comment == null)
                throw new BusinessException(CommentMessages.CommentDoesNotExist);
            return Task.CompletedTask;
        }
    }
}
