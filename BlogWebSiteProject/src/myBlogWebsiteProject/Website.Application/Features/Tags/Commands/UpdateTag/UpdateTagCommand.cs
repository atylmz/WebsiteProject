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

namespace Website.Application.Features.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<UpdatedTagDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdatedTagDto>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public UpdateTagCommandHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<UpdatedTagDto> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
            {
                await _tagBusinessRules.TagTitleShouldNotBeExistWhenUpdate(request.Title);
                await _tagBusinessRules.TagShouldBeExistWhenUpdate(request.Id);

                Tag mappedTag = _mapper.Map<Tag>(request);
                Tag updatedTag = await _tagRepository.UpdateAsync(mappedTag);
                UpdatedTagDto updatedTagDto = _mapper.Map<UpdatedTagDto>(updatedTag);

                return updatedTagDto;
            }
        }
    }
}
