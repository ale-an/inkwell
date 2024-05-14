using DataLayer.Entities.Articles;
using DataLayer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public class ArticleRepository : BaseRepository<Article>
{
    public ArticleRepository(ApplicationContext context) : base(context)
    {
    }

    public override Article? Get(int id)
    {
        return Set.Include(x => x.Tags)
            .Include(x => x.Comments)
            .ThenInclude(x => x.User)
            .SingleOrDefault(x => x.Id == id);
    }
}