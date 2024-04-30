using DataLayer.Entities.Articles;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class ArticleRepository : BaseRepository<Article>
{
    public ArticleRepository(ApplicationContext context) : base(context)
    {
    }
}