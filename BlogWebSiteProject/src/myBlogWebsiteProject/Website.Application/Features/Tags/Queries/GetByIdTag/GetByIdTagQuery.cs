using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Features.Tags.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Tags.Queries.GetByIdTag
{
    public class GetByIdTagQuery : IRequest<TagDto>
    {
        public int Id { get; set; }

        public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQuery, TagDto>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _ruleBusinessRules;

            public GetByIdTagQueryHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules ruleBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _ruleBusinessRules = ruleBusinessRules;
            }

            public async Task<TagDto> Handle(GetByIdTagQuery request, CancellationToken cancellationToken)
            {
                await _ruleBusinessRules.TagShouldBeExistWhenSelected(request.Id);

                Tag? tag = await _tagRepository.GetAsync(x => x.Id == request.Id);
                TagDto tagDto = _mapper.Map<TagDto>(tag);

                return tagDto;
            }
        }
    }
}
