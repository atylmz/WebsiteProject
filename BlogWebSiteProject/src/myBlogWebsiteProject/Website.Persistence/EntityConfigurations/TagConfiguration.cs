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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.MetaTitle).HasColumnName("MetaTitle");
            builder.Property(p => p.Slug).HasColumnName("Slug");
            builder.Property(p => p.Content).HasColumnName("Content");
            builder.HasMany(p => p.ArticleTags);
        }
    }
}
