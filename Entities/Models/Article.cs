using Shared.Entities.Abstract;

namespace Entities.Models;

public class Article : EntityBase, IEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Thumbnail { get; set; }
    public DateTime Date { get; set; }
    public int ViewsCount { get; set; } = 0;
    public int CommentCount { get; set; } = 0;
    public string? SeoAuthor { get; set; }
    public string? SeoDescription { get; set; }
    public string? SeoTag { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<Comment>? Comments { get; set; }
}
