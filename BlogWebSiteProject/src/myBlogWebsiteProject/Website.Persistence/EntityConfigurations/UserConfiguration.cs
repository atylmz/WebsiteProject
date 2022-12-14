using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.FirstName).HasColumnName("FirstName");
            builder.Property(u => u.LastName).HasColumnName("LastName");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.HasIndex(u => u.Email, "UK_Users_Email").IsUnique();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
            builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");


            User user = new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                AuthenticatorType = Core.Security.Enums.AuthenticatorType.Email,
                Email = "admin@admin.com",
                Status = true,

            };
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash("admin" , out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            User[] userSeed = new[] { user };

            builder.HasData(userSeed);
        }
    }
}
