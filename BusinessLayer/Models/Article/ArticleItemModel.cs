using BusinessLayer.Models.Comment;

namespace BusinessLayer.Models.Article;

public class ArticleItemModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

    public List<string> Tags { get; } = new();
    public List<CommentItemModel> Comments { get; } = new();
}