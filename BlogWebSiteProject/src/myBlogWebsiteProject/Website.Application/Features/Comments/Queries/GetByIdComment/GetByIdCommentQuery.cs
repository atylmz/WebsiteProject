using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Queries.GetByIdComment
{
    public class GetByIdCommentQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }

        public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, CommentDto>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentsBusinessRules _commentsBusinessRules;

            public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, CommentsBusinessRules commentsBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentsBusinessRules = commentsBusinessRules;
            }

            public async Task<CommentDto> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
            {
                Comment? comment = await _commentRepository.GetAsync(x => x.Id == request.Id,
                                                                     include: x => x.Include(x => x.Article));

                await _commentsBusinessRules.CommentShouldBeExistWhenSelect(comment);

                CommentDto commentDto = _mapper.Map<CommentDto>(comment);

                return commentDto;
            }
        }
    }
}
