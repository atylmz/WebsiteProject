﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Application.Features.ArticleMetas.Dtos
{
    public class CreatedArticleMetaDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
    }
}
