namespace Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context)
        : base(context)
    {
    }
}
