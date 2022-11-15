using Core.Persistence.Repositories;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
