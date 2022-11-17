using AutoMapper;
using MediatR;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Comments.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<UpdatedCommentDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] { Admin, CommentUpdate };

        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentDto>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentsBusinessRules _commentBusinessRules;

            public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentsBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<UpdatedCommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                await _commentBusinessRules.CommentShouldBeExistWhenUpdate(request.Id);

                Comment mappedComment = _mapper.Map<Comment>(request);
                Comment createdComment = await _commentRepository.UpdateAsync(mappedComment);
                UpdatedCommentDto updatedCommentDto = _mapper.Map<UpdatedCommentDto>(createdComment);

                return updatedCommentDto;
            }
        }
    }
}
