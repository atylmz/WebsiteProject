using AutoMapper;
using MediatR;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Features.Tags.Rules;
using Website.Application.Services.Repositories;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Tags.Contants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<CreatedTagDto>, ISecuredRequest
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] { Admin, TagAdd };

        public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreatedTagDto>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<CreatedTagDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
            {
                await _tagBusinessRules.TagTitleShouldNotBeExistWhenCreate(request.Title);

                Domain.Entites.Tag mappedTag = _mapper.Map<Domain.Entites.Tag>(request);
                Domain.Entites.Tag createdTag =await _tagRepository.AddAsync(mappedTag);
                CreatedTagDto dto = _mapper.Map<CreatedTagDto>(createdTag);

                return dto;
            }
        }
    }
}
