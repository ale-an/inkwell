namespace DataLayer.Entities.Articles;

public class Tag : StandardEntity
{
    public string? Name { get; set; }
    public List<Article> Articles { get; set; } = new();
}