namespace Data.Repositories;

public class CategoryRepsoitory : Repository<Category>, ICategoryReposiyory
{
    public CategoryRepsoitory(DbContext context) 
        : base(context)
    {
    }
}
