﻿using Core.Persistence.Repositories;

namespace Website.Application.Features.Authors.Dtos
{
    public class CreatedAuthorDto : BaseDto
    {
        public int UserId { get; set; }
        public string Description { get; set; }
    }

}
