using Shared.Entities.Abstract;

namespace Entities.Models;

public class User : EntityBase, IEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public string? Picture { get; set; }
    public string? Description { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public List<Article>? Articles { get; set; }
}