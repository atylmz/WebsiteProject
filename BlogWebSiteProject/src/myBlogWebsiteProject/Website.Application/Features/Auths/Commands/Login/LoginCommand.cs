using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Auths.Dtos;
using Website.Application.Features.Auths.Rules;
using Website.Application.Services.AuthService;
using Website.Application.Services.UserSevice;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Website.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IPAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserService userService, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserPasswordShouldBeMatched(user.Id, request.UserForLoginDto.Password);

                LoggedDto loggedDto = new();

                if (user.AuthenticatorType is not AuthenticatorType.None)
                {
                    if(request.UserForLoginDto.AuthenticatorCode is null)
                    {
                        await _authService.SendAuthenticatorCode(user);
                        loggedDto.RequiredAuthenticatorType = user.AuthenticatorType;
                        return loggedDto;
                    }

                    await _authService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
                }

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                await _authService.DeleteOldRefreshTokens(user.Id);

                loggedDto.AccessToken = createdAccessToken;
                loggedDto.RefreshToken = addedRefreshToken;
                return loggedDto;
            }
        }
    }
}
