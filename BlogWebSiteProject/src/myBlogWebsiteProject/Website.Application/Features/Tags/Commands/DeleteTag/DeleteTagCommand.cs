using AutoMapper;
using MediatR;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Tags.Contants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<DeletedTagDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, TagDelete };

        public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeletedTagDto>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;

            public DeleteTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTagDto> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
            {
                Tag mappedTag = _mapper.Map<Tag>(request);
                Tag deletedTag =await _tagRepository.DeleteAsync(mappedTag);
                DeletedTagDto deletedTagDto = _mapper.Map<DeletedTagDto>(deletedTag);

                return deletedTagDto;
            }
        }
    }
}
