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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ArticleId).HasColumnName("ArticleId");
            builder.Property(p => p.ParentId).HasColumnName("ParentId");
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.Published).HasColumnName("Published");
            builder.Property(p => p.PublishedAt).HasColumnName("PublishedAt");
            builder.Property(p => p.Content).HasColumnName("Content");
            builder.HasOne(p => p.ParentComment).WithMany(p => p.ParentComments).HasForeignKey(p => p.ParentId);
            builder.HasOne(p => p.Article);
        }
    }
}
