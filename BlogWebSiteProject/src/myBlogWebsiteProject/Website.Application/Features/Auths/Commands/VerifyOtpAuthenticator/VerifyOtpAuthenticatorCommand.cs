using Core.Security.Entities;
using MediatR;
using Website.Application.Features.Auths.Rules;
using Website.Application.Services.AuthService;
using Website.Application.Services.Repositories;
using Website.Application.Services.UserSevice;

namespace Website.Application.Features.Auths.Commands.VerifyOtpAuthenticator
{
    public class VerifyOtpAuthenticatorCommand : IRequest
    {
        public int UserId { get; set; }
        public string ActivationCode { get; set; }

        public class VerifyOtpAuthenticatonCommandHandler : IRequestHandler<VerifyOtpAuthenticatorCommand>
        {
            private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserService _userService;
            private readonly IAuthService _authService;

            public VerifyOtpAuthenticatonCommandHandler(IOtpAuthenticatorRepository otpAuthenticatorRepository,
                AuthBusinessRules authBusinessRules,
                IUserService userService,
                IAuthService authService)
            {
                _otpAuthenticatorRepository = otpAuthenticatorRepository;
                _authBusinessRules = authBusinessRules;
                _userService = userService;
                _authService = authService;
            }

            public async Task<Unit> Handle(VerifyOtpAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                OtpAuthenticator? otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(e => e.UserId == request.UserId);

                await _authBusinessRules.OtpAuthenticaticatorShouldBeExists(otpAuthenticator);

                User user = await _userService.GetById(request.UserId);

                otpAuthenticator.IsVerified = true;
                user.AuthenticatorType = Core.Security.Enums.AuthenticatorType.Otp;

                await _authService.VerifyAuthenticatorCode(user, request.ActivationCode);

                await _otpAuthenticatorRepository.UpdateAsync(otpAuthenticator);
                await _userService.Update(user);

                return Unit.Value;
            }
        }
    }
}
