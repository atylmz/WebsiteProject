using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<DeletedTagDto>
    {
        public int Id { get; set; }

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
