using Shared.Entities.Abstract;

namespace Entities.Models;

public class User : EntityBase, IEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public string? Picture { get; set; }
    public string? Description { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public List<Article>? Articles { get; set; }
}
