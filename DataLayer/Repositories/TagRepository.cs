using DataLayer.Entities.Articles;
using DataLayer.Repositories.Base;

namespace DataLayer.Repositories;

public class TagRepository : BaseRepository<Tag>
{
    public TagRepository(ApplicationContext db) : base(db)
    {
    }

    public Tag[] GetByArticle(int articleId)
    {
        return Set.Where(x => x.Articles.Any(z => z.Id == articleId)).ToArray();
    }

    public void SaveIfNotExist(IEnumerable<string> tags, Article article)
    {
        foreach (var tag in tags)
        {
            var tagDb = Set.SingleOrDefault(z => z.Name == tag);

            if (tagDb == null)
                Create(new Tag
                {
                    Name = tag,
                    Articles = new List<Article>()
                    {
                        article
                    }
                });
            else
            {
                if (article.Tags.All(z => z.Name != tag))
                    tagDb.Articles.Add(article);
            }
        }

        Context.SaveChanges();
    }
}