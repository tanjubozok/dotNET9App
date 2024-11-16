﻿namespace Shared.Entities.Abstract;

public abstract class EntityBase
{
    public virtual int Id { get; set; }
    public virtual DateTime CratedDate { get; set; } = DateTime.Now;
    public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
    public virtual bool IsDeleted { get; set; } = false;
    public virtual bool IsActive { get; set; } = true;
    public virtual required string CreatedByName { get; set; } = "Admin";
    public virtual string? ModifiedByName { get; set; } = "Admin";
    public virtual string? Note { get; set; }
}
