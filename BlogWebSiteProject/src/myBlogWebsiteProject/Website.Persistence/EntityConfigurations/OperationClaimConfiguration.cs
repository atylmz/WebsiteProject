using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.ArticleCategories.Constants.OperationClaims;
using static Website.Application.Features.ArticleMetas.Constants.OperationClaims;
using static Website.Application.Features.ArticleTags.Constants.OperationClaims;
using static Website.Application.Features.Articles.Constants.OperationClaims;
using static Website.Application.Features.Authors.Constants.OperationClaims;
using static Website.Application.Features.Categories.Constants.OperationClaims;
using static Website.Application.Features.Comments.Constants.OperationClaims;
using static Website.Application.Features.OperationClaims.Constants.OperationClaims;
using static Website.Application.Features.UserOperationClaims.Constants.OperationClaims;
using static Website.Application.Features.Users.Constants.OperationClaims;
using static Website.Application.Features.Tags.Contants.OperationClaims;

namespace Website.Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(o => o.Name).HasColumnName("Name");
            builder.HasIndex(o => o.Name, "UK_OperationClaims_Name").IsUnique();

            OperationClaim[] operationClaimSeeds = 
            {
                new(1, Admin),
                new(2, ArticleCategoryAdd),
                new(3, ArticleCategoryUpdate),
                new(4, ArticleCategoryDelete),
                new(5, ArticleMetasAdd),
                new(6, ArticleMetasUpdate),
                new(7, ArticleMetasDelete),
                new(8, ArticleTagAdd),
                new(9, ArticleTagUpdate),
                new(10, ArticleTagDelete),
                new(11, ArticleAdd),
                new(12, ArticleUpdate),
                new(13, ArticleDelete),
                new(14, AuthorAdd),
                new(15, AuthorUpdate),
                new(16, AuthorDelete),
                new(17, CategoryAdd),
                new(18, CategoryUpdate),
                new(19, CategoryDelete),
                new(20, CommentAdd),
                new(21, CommentUpdate),
                new(22, CommentDelete),
                new(23, OperationClaimAdd),
                new(24, OperationClaimUpdate),
                new(25, OperationClaimDelete),
                new(26, UserOperationClaimAdd),
                new(27, UserOperationClaimUpdate),
                new(28, UserOperationClaimDelete),
                new(29, UserAdd),
                new(30, UserUpdate),
                new(31, UserDelete),
                new(32, TagAdd),
                new(33, TagUpdate),
                new(34, TagDelete),
            };
            builder.HasData(operationClaimSeeds);
        }
    }
}
