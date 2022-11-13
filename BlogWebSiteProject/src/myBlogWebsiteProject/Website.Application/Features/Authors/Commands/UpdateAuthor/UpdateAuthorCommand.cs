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

namespace Website.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<UpdatedAuthorDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdatedAuthorDto>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;
            private readonly AuthorsBusinessRules _authorsBusinessRules;

            public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, AuthorsBusinessRules authorsBusinessRules)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
                _authorsBusinessRules = authorsBusinessRules;
            }

            public async Task<UpdatedAuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                await _authorsBusinessRules.AuthorShouldBeExistWhenUpdate(request.Id);
                await _authorsBusinessRules.AuthorShouldBeExistWhenUpdate(request.UserId);

                Author mappedAuthor = _mapper.Map<Author>(request);
                Author updatedAuthor = await _authorRepository.UpdateAsync(mappedAuthor);
                UpdatedAuthorDto updatedAuthorDto = _mapper.Map<UpdatedAuthorDto>(updatedAuthor);

                return updatedAuthorDto;
            }
        }
    }
}
