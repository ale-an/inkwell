using DataLayer.Entities.Articles;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class CommentRepository : BaseRepository<Comment>
{
    public CommentRepository(ApplicationContext db) : base(db)
    {
    }
}