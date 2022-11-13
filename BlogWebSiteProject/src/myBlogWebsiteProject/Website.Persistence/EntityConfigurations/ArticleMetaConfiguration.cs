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
    public class ArticleMetaConfiguration : IEntityTypeConfiguration<ArticleMeta>
    {
        public void Configure(EntityTypeBuilder<ArticleMeta> builder)
        {
            builder.ToTable("ArticleMetas").HasKey(k => k.Id);
            builder.Property(p=>p.Id).HasColumnName("Id");
            builder.Property(p=>p.ArticleId).HasColumnName("ArticleId");
            builder.Property(p=>p.Key).HasColumnName("Key");
            builder.Property(p=>p.Content).HasColumnName("Content");
            builder.HasOne(p => p.Article);

        }
    }
}
