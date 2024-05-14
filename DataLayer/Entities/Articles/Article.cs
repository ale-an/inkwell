using DataLayer.Entities.Users;

namespace DataLayer.Entities.Articles;

public class Article : StandardEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<Tag> Tags { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}