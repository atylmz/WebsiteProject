using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.Categories.Dtos
{
    public class CategoryDto : BaseDto
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
    }
}
