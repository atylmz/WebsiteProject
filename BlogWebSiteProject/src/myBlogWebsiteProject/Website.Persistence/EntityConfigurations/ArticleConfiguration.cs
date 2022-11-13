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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.AuthorId).HasColumnName("AuthorId");
            builder.Property(p => p.ParentId).HasColumnName("ParentId");
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.MetaTitle).HasColumnName("MetaTitle");
            builder.Property(p => p.Slug).HasColumnName("Slug");
            builder.Property(p => p.Summary).HasColumnName("Summary");
            builder.Property(p => p.PublishedAt).HasColumnName("PublishedAt");
            builder.Property(p => p.Published).HasColumnName("Published");
            builder.Property(p => p.Content).HasColumnName("Content");
            builder.HasOne(p => p.Author);
            //builder.HasOne(p=>p.ParentArticle).WithMany(p=>p.ParentArticles).HasForeignKey(p=>p.ParentId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany(p => p.ArticleMetas);
            builder.HasMany(p => p.ArticleTags);
            builder.HasMany(p => p.ArticleCategories);

        }
    }
}
