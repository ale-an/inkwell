namespace BusinessLayer.Models;

public class ArticleModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
    public DateTime PublicationDate { get; set; }
}