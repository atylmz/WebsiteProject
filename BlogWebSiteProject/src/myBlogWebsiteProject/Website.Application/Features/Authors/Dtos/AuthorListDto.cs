using Core.Persistence.Repositories;

namespace Website.Application.Features.Authors.Dtos
{
    public class AuthorListDto : BaseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
    }

}
