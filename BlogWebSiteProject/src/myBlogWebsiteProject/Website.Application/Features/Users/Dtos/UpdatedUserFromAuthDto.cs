using Core.Persistence.Repositories;
using Core.Security.JWT;

namespace Website.Application.Features.Users.Dtos
{
    public class UpdatedUserFromAuthDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
