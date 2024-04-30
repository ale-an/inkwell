using DataLayer.Entities.Users;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(ApplicationContext db) : base(db)
    {
    }

    public User? Get(string email, string password)
    {
        return GetAll().SingleOrDefault(x => x.Email == email && x.Password == password);
    }
}