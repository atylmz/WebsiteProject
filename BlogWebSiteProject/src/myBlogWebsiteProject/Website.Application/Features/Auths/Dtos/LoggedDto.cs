using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Auths.Dtos
{
    public class LoggedDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public LoggedResponseDto CreateResponseDto()
        {
            return new LoggedResponseDto()
            {
                AccessToken = AccessToken,
                RequiredAuthenticatorType = RequiredAuthenticatorType
            };
        }

        public class LoggedResponseDto
        {
            public AccessToken? AccessToken { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }
    }
}
