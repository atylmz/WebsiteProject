using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Auths.Commands.EnableEmailAuthenticator;
using Website.Application.Features.Auths.Commands.EnableOtpAuthenticator;
using Website.Application.Features.Auths.Commands.Login;
using Website.Application.Features.Auths.Commands.RefleshToken;
using Website.Application.Features.Auths.Commands.Register;
using Website.Application.Features.Auths.Commands.RevokeToken;
using Website.Application.Features.Auths.Commands.VerifyEmailAuthenticator;
using Website.Application.Features.Auths.Commands.VerifyOtpAuthenticator;
using Website.Application.Features.Auths.Dtos;
using Core.Security.Extensions;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WebAPIConfiguration _configuration;
        private IMediator? _mediator;

        private IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IPAddress = getIpAddress() };
            LoggedDto result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null) setRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.CreateResponseDto());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IPAddress = getIpAddress() };
            RegisteredDto result = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshToken = new() { RefleshToken = getRefreshTokenFromCookies(), IPAddress = getIpAddress() };
            RefreshedTokensDto result = await Mediator.Send(refreshToken);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPut("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior.Allow)] string? refreshToken)
        {
            RevokeTokenCommand revokeTokenCommand = new() { Token = refreshToken ?? getRefreshTokenFromCookies(), IPAddress = getIpAddress() };
            RevokedTokenDto result = await Mediator.Send(revokeTokenCommand);
            return Ok(result);
        }

        [HttpGet("EnableEmailAuthenticator")]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest(),
                VerifyEmailUrlPrefix = $"{_configuration.APIDomain}/Auth/VerifyEmailAuthenticator"
            };
            await Mediator.Send(enableEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpGet("EnableOtpAuthenticator")]
        public async Task<IActionResult> EnableOtpAuthenticator()
        {
            EnableOtpAuthenticatorCommand enableOtpAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest()
            };
            await Mediator.Send(enableOtpAuthenticatorCommand);
            return Ok();
        }

        [HttpGet("VerifyEmailAuthenticator")]
        public async Task<IActionResult> VerifyEmailAuthenticator([FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
        {
            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpGet("VerifyOtpAuthenticator")]
        public async Task<IActionResult> VerifyOtpAuthenticator([FromQuery] VerifyOtpAuthenticatorCommand verifyOtpAuthenticatorCommand)
        {
            await Mediator.Send(verifyOtpAuthenticatorCommand);
            return Ok();
        }

        private string getRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }

        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        private string? getIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        private int getUserIdFromRequest() //todo authentication behavior?
        {
            int userId = HttpContext.User.GetUserId();
            return userId;
        }
    }
}
