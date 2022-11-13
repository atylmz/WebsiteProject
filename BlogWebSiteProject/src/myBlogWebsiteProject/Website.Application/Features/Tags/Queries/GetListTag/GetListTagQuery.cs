using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Models;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Tags.Queries.GetListTag
{
    public class GetListTagQuery : IRequest<TagListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetListTagQuery, TagListModel>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(ITagRepository tagRepository, IMapper mapper)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
            }

            public async Task<TagListModel> Handle(GetListTagQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Tag> tags = await _tagRepository.GetListAsync(index: request.PageRequest.Page,
                                                                        size: request.PageRequest.PageSize);

                TagListModel tagListModel = _mapper.Map<TagListModel>(tags);

                return tagListModel;
            }
        }
    }
}
