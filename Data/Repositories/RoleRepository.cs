namespace Data.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(DbContext context)
        : base(context)
    {
    }
}
