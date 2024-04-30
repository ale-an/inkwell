using DataLayer.Entities.Users;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class RoleRepository : BaseRepository<Role>
{
    public RoleRepository(ApplicationContext db) : base(db)
    {
    }

    public Role? GetRoleByUserId(int userId)
    {
        var userRole = Context.UserRoles?.Find(userId);

        return userRole == null ? null : Get(userRole.RoleId);
    }
}