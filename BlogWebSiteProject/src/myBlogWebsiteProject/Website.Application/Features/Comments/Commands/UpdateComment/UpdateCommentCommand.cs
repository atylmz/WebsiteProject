﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<UpdatedCommentDto>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

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
