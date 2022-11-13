using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Authors.Models;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Authors.Queries.GetListAuthor
{
    public class GetListAuthorQuery : IRequest<AuthorListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListAuthorQueryHandler : IRequestHandler<GetListAuthorQuery, AuthorListModel>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;

            public GetListAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
            }

            public async Task<AuthorListModel> Handle(GetListAuthorQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Author> authors = await _authorRepository
                    .GetListAsync(size: request.PageRequest.PageSize,
                                  index: request.PageRequest.Page,
                                  include: x => x.Include(x => x.User));
                AuthorListModel authorListModel = _mapper.Map<AuthorListModel>(authors);

                return authorListModel;
            }
        }
    }
}
