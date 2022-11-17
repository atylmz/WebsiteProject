using AutoMapper;
using MediatR;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.CommentService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Comments.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<DeletedCommentDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, CommentDelete };

        public class DeleteCommandCommandHandler : IRequestHandler<DeleteCommentCommand, DeletedCommentDto>
        {
            private readonly ICommentService _commentService;
            private readonly IMapper _mapper;
            private readonly CommentsBusinessRules _commentsBusinessRules;

            public DeleteCommandCommandHandler(ICommentService commentService, IMapper mapper, CommentsBusinessRules commentsBusinessRules)
            {
                _commentService = commentService;
                _mapper = mapper;
                _commentsBusinessRules = commentsBusinessRules;
            }

            public async Task<DeletedCommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                await _commentsBusinessRules.CommentShouldBeExistWhenDelete(request.Id);

                Comment mappedComment = _mapper.Map<Comment>(request);
                Comment deletedComment = await _commentService.DeleteComment(mappedComment);
                DeletedCommentDto deletedCommentDto = _mapper.Map<DeletedCommentDto>(deletedComment);

                return deletedCommentDto;
            }
        }
    }
}
