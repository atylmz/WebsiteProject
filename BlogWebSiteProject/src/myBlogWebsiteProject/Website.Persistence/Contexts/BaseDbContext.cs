using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Website.Domain.Entites;


namespace Website.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<Article> Articles{ get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<ArticleMeta> ArticleMeta { get; set; }
        public DbSet<ArticleTag> ArticleTags{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
