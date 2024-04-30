using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.Users;

namespace DataLayer.Entities.Articles;

public class Comment : StandardEntity
{
    public int ArticleId { get; set; }
    public Article? Article { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
}