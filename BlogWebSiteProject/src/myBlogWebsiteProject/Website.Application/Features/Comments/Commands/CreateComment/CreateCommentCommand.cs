using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Comments.Dtos;

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
            public Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
