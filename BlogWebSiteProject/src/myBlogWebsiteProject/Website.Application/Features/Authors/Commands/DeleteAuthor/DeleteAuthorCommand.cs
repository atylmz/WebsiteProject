using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Authors.Dtos;
using Website.Application.Features.Authors.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<DeletedAuthorDto>
    {
        public int Id { get; set; }

        public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeletedAuthorDto>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;
            private readonly AuthorsBusinessRules _authorsBusinessRules;

            public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, AuthorsBusinessRules authorsBusinessRules)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
                _authorsBusinessRules = authorsBusinessRules;
            }

            public async Task<DeletedAuthorDto> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
            {
                await _authorsBusinessRules.AuthorShouldBeExistWhenDelete(request.Id);

                Author mappedAuthor = _mapper.Map<Author>(request);
                Author deletedAuthor = await _authorRepository.DeleteAsync(mappedAuthor);
                DeletedAuthorDto deletedAuthorDto = _mapper.Map<DeletedAuthorDto>(deletedAuthor);

                return deletedAuthorDto;
            }
        }
    }
}
