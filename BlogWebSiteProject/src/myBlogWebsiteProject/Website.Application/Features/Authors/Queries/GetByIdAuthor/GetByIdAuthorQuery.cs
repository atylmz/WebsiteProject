using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Website.Application.Features.Authors.Dtos;
using Website.Application.Features.Authors.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Authors.Queries.GetByIdAuthor
{
    public class GetByIdAuthorQuery : IRequest<AuthorDto>
    {
        public int Id { get; set; }

        public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, AuthorDto>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;
            private readonly AuthorsBusinessRules _authorsBusinessRules;

            public GetByIdAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper, AuthorsBusinessRules authorsBusinessRules)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
                _authorsBusinessRules = authorsBusinessRules;
            }

            public async Task<AuthorDto> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
            {
                Author? author = await _authorRepository.GetAsync(predicate: x => x.Id == request.Id,
                                                                  include: x => x.Include(x => x.User));

                await _authorsBusinessRules.AuthorShouldBeExistWhenSelected(author);

                AuthorDto authorDto = _mapper.Map<AuthorDto>(author);

                return authorDto;
            }
        }
    }
}
