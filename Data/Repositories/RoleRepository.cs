using Data.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;

namespace Data.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(DbContext context) : base(context)
    {
    }
}
