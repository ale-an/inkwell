namespace BusinessLayer.Models.Comment;

public class CommentItemModel
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public string? Author { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
}