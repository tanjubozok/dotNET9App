using Shared.Entities.Abstract;

namespace Entities.Models;

public class Role : EntityBase, IEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public List<User>? Users { get; set; }
}
