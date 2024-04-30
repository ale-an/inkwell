using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Users;

public class Role : StandardEntity
{
    public string Name { get; set; }
}