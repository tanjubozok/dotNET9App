using Data.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;

namespace Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}
