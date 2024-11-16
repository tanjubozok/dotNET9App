using Data.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;

namespace Data.Repositories;

public class CategoryRepsoitory : Repository<Category>, ICategoryReposiyory
{
    public CategoryRepsoitory(DbContext context) : base(context)
    {
    }
}
