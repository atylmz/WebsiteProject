using Core.Security.Entities;
using Core.Security.JWT;
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

namespace Website.Application.Features.Auths.Commands.RefleshToken
{
    public class RefreshTokenCommand : IRequest<RefreshedTokensDto>
    {
        public string? RefleshToken { get; set; }
        public string? IPAddress { get; set; }

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshedTokensDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _authBusinessRules;

            public RefreshTokenCommandHandler(IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _userService = userService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RefreshedTokensDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefleshToken);
                await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

                if (refreshToken.Revoked != null)
                    await _authService.RevokeDescendantRefreshTokens(refreshToken, request.IPAddress,
                        $"Attempted reuse of revoked ancestor token : {refreshToken.Token}");
                
                await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

                User user = await _userService.GetById(refreshToken.Id);

                RefreshToken newRefreshToken = await _authService.RotateRefreshToken(user, refreshToken, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);

                await _authService.DeleteOldRefreshTokens(refreshToken.UserId);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshedTokensDto refreshedTokensDto = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
                return refreshedTokensDto;
            }
        }
    }
}
