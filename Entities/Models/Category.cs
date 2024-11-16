using Shared.Entities.Abstract;

namespace Entities.Models;

public class Category : EntityBase, IEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public List<Article>? Articles { get; set; }
}
