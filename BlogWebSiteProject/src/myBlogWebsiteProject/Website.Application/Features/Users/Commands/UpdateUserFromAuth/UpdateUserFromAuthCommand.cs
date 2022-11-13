using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Users.Dtos;
using Website.Application.Features.Users.Rules;
using Website.Application.Services.AuthService;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.Users.Commands.UpdateUserFromAuth
{
    public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthDto> 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }

        public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthDto>
        {

            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IAuthService _authService;

            public UpdateUserFromAuthCommandHandler(IUserRepository userRepository, IMapper mapper,
                                                    UserBusinessRules userBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _authService = authService;
            }

            public async Task<UpdatedUserFromAuthDto> Handle(UpdateUserFromAuthCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(x => x.Id == request.Id);

                await _userBusinessRules.UserShouldBeExist(user);
                await _userBusinessRules.UserPAssordShouldBeMatch(user, request.Password);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                if(request.NewPassword is not null && !string.IsNullOrEmpty(request.NewPassword))
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                    user.PasswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;
                }

                User updateUser = await _userRepository.UpdateAsync(user);
                UpdatedUserFromAuthDto updatedUserDto = _mapper.Map<UpdatedUserFromAuthDto>(updateUser);
                updatedUserDto.AccessToken = await _authService.CreateAccessToken(user);
                return updatedUserDto;
            }
        }
    }
}
