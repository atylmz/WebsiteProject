using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Auths.Dtos
{
    public class RevokedTokenDto
    {
        public int Id{ get; set; }
        public string Token { get; set; }
    }
}
