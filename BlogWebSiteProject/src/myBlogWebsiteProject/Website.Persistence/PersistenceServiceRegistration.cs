using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website.Application.Services.Repositories;
using Website.Persistence.Contexts;
using Website.Persistence.Repositories;

namespace Website.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                options.UseSqlServer(
                                                    configuration.GetConnectionString("MyWebsiteConnectionString")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleMetaRepository, ArticleMetaRepository>();
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IArticleTagRepository, ArticleTagRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            return services;
        }

    }
}
