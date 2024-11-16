using Shared.Entities.Abstract;

namespace Entities.Models;

public class Comment : EntityBase, IEntity
{
    public string Text { get; set; } = string.Empty;

    public int ArticleId { get; set; }
    public Article? Article { get; set; }
}
