using DataLayer.Entities.Articles;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class TagRepository : BaseRepository<Tag>
{
    public TagRepository(ApplicationContext db) : base(db)
    {
    }
}