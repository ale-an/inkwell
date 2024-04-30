using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ArticleService>();
        services.AddScoped<ClaimService>();
        services.AddScoped<CommentService>();
        services.AddScoped<TagService>();
        services.AddScoped<UserService>();
    }
}