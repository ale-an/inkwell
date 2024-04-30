using DataLayer.Entities.Articles;
using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class ApplicationContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Tag>? Tags { get; set; }
    public DbSet<Comment>? Comments { get; set; }
    public DbSet<Article>? Articles { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
}