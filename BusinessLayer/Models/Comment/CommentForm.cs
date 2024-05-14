namespace BusinessLayer.Models.Comment;

public class CommentForm
{
    public int? Id { get; set; }
    public int ArticleId { get; set; }
    public string? Text { get; set; }
}