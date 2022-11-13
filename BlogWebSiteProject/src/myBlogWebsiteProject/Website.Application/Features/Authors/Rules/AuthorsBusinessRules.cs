using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Website.Application.Features.Authors.Constants;
using Website.Application.Services.Repositories;
using Website.Application.Services.UserSevice;
using Website.Domain.Entites;

namespace Website.Application.Features.Authors.Rules
{
    public class AuthorsBusinessRules : BaseBusinessRules
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserService _userService;

        public AuthorsBusinessRules(IAuthorRepository authorRepository, IUserService userService)
        {
            _authorRepository = authorRepository;
            _userService = userService;
        }

        public async Task UserShouldExistWhenInsert(int userId)
        {
            User? user = await _userService.GetById(userId);
            if (user is null)
                throw new BusinessException(AuthorMessages.UserDoesNotExist);
        }

        public async Task UserShouldExistWhenUpdate(int userId)
        {
            User? user = await _userService.GetById(userId);
            if (user is null)
                throw new BusinessException(AuthorMessages.UserDoesNotExist);
        }

        public async Task AuthorShouldBeExistWhenUpdate(int id)
        {
            Author? author = await _authorRepository.GetAsync(x => x.Id == id);
            if (author is null)
                throw new BusinessException(AuthorMessages.AuthorDoesNotExist);
        }

        public async Task AuthorShouldBeExistWhenDelete(int id)
        {
            Author? author = await _authorRepository.GetAsync(x => x.Id == id);
            if (author is null)
                throw new BusinessException(AuthorMessages.AuthorDoesNotExist);
        }

        public Task AuthorShouldBeExistWhenSelected(Author? author)
        {
            if (author is null)
                throw new BusinessException(AuthorMessages.AuthorDoesNotExist);
            return Task.CompletedTask;
        }
    }
}
