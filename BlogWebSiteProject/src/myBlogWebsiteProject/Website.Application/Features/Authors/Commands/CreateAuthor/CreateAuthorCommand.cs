using AutoMapper;
using MediatR;
using Website.Application.Features.Authors.Dtos;
using Website.Application.Features.Authors.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Authors.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<CreatedAuthorDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public string Description { get; set; }

        public string[] Roles => new[] { Admin, AuthorAdd };

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreatedAuthorDto>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;
            private readonly AuthorsBusinessRules _authorsBusinessRules;

            public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, AuthorsBusinessRules authorsBusinessRules)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
                _authorsBusinessRules = authorsBusinessRules;
            }

            public async Task<CreatedAuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                await _authorsBusinessRules.UserShouldExistWhenInsert(request.UserId);

                Author mappedAuthor = _mapper.Map<Author>(request);
                Author createdAuthor = await _authorRepository.AddAsync(mappedAuthor);
                CreatedAuthorDto createdAuthorDto = _mapper.Map<CreatedAuthorDto>(createdAuthor);

                return createdAuthorDto;
            }
        }
    }
}
