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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        { 
            builder.ToTable("Categories").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ParentId).HasColumnName("ParentId");
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.MetaTitle).HasColumnName("MetaTitle");
            builder.Property(p => p.Slug).HasColumnName("Slug");
            builder.Property(p => p.Content).HasColumnName("Content");
            //builder.HasMany(x=>x.ParentCategories).WithOptional(x=>x.ParentCategories).HasForeignKey(p => p.ParentId)
            //    .OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany(p => p.ArticleCategories);
        }
    }
}
