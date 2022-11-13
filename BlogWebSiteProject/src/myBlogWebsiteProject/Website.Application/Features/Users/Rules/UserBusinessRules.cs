using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Website.Application.Features.Auths.Constants;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.Users.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserIdShouldExistWhenSelected(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (user == null) throw new BusinessException(AuthMessages.UserDontExists);
        }

        public Task UserShouldBeExist(User? user)
        {
            if (user is null) throw new BusinessException(AuthMessages.UserDontExists);
            return Task.CompletedTask;
        }

        public Task UserPAssordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(AuthMessages.PasswordDontMatch);
            return Task.CompletedTask;
        }
    }
}
