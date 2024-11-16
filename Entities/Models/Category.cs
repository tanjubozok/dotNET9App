﻿using Shared.Entities.Abstract;

namespace Entities.Models;

public class Category : EntityBase, IEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public List<Article>? Articles { get; set; }
}
