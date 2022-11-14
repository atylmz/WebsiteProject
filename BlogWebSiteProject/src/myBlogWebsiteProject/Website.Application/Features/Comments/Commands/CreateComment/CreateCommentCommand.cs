using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.CommentService;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CreatedCommentDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

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
                if(request.Id != 0)
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
