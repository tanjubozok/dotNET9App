namespace Data.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(DbContext context) 
        : base(context)
    {
    }
}
