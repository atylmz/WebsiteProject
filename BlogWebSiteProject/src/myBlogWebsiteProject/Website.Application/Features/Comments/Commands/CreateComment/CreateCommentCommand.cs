using AutoMapper;
using MediatR;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.CommentService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Comments.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CreatedCommentDto>, ISecuredRequest
    {
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] { Admin, CommentAdd };

        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentDto>
        {
            private readonly ICommentService _commentService;
            private readonly IMapper _mapper;
            private readonly CommentsBusinessRules _commentBusinessRules;

            public CreateCommentCommandHandler(ICommentService commentService, IMapper mapper, CommentsBusinessRules commentBusinessRules)
            {
                _commentService = commentService;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                if (request.ParentId != 0)
                {
                    await _commentBusinessRules.SubCommentCanHaveOnlyOneParent(request.ParentId);
                    await _commentBusinessRules.CommentShouldBeExistWhenSubCommentCreate(request.ParentId);
                }

                Comment mappedComment = _mapper.Map<Comment>(request);
                Comment createdComment = await _commentService.CreateComment(mappedComment);
                CreatedCommentDto createdCommentDto = _mapper.Map<CreatedCommentDto>(createdComment);

                return createdCommentDto;
            }
        }
    }
}
