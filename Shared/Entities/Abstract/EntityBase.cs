namespace Shared.Entities.Abstract;

public abstract class EntityBase
{
    public virtual int Id { get; set; }
    public virtual DateTime? CratedDate { get; set; }
    public virtual DateTime? ModifiedDate { get; set; }
    public virtual bool IsDeleted { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual string CreatedByName { get; set; } = string.Empty;
    public virtual string? ModifiedByName { get; set; }
    public virtual string? Note { get; set; }
}
