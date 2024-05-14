namespace DataLayer.Entities.Users;

public class User : StandardEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public UserRole? UserRole { get; set; }
}