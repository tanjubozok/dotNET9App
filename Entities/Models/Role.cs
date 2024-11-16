using Shared.Entities.Abstract;

namespace Entities.Models;

public class Role : EntityBase, IEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public List<User>? Users { get; set; }
}
