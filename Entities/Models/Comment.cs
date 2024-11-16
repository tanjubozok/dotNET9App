using Shared.Entities.Abstract;

namespace Entities.Models;

public class Comment : EntityBase, IEntity
{
    public required string Text { get; set; }

    public int ArticleId { get; set; }
    public Article? Article { get; set; }
}
