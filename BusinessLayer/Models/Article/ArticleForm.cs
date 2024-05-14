namespace BusinessLayer.Models.Article;

public class ArticleForm
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public List<string> Tags { get; } = new();
}