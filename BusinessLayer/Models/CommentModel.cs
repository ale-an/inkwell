namespace BusinessLayer.Models;

public class CommentModel
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int UserId { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
}