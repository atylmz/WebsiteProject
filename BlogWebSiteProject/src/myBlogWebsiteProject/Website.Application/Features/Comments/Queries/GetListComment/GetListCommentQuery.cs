using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Website.Application.Features.Comments.Models;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Comments.Queries.GetListComment
{
    public class GetListCommentQuery : IRequest<CommentListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, CommentListModel>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;

            public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<CommentListModel> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> comments = await _commentRepository
                    .GetListAsync(size: request.PageRequest.PageSize,
                                  index: request.PageRequest.Page,
                                  include: p=>p.Include(i=>i.Article));
                CommentListModel commentListModel = _mapper.Map<CommentListModel>(comments);

                return commentListModel;
            }
        }
    }
}
