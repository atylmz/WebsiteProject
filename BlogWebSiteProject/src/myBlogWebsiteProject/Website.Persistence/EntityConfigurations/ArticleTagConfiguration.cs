using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;

namespace Website.Persistence.EntityConfigurations
{
    public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.ToTable("ArticleTags").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ArticleId).HasColumnName("ArticleId");
            builder.Property(p => p.TagId).HasColumnName("TagId");
            builder.HasOne(p => p.Article);
            builder.HasOne(p => p.Tag);
        }
    }
}
