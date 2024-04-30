using DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ArticleRepository>();
        services.AddScoped<CommentRepository>();
        services.AddScoped<RoleRepository>();
        services.AddScoped<TagRepository>();
        services.AddScoped<UserRepository>();
    }
}