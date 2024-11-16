using Data.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;

namespace Data.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(DbContext context) : base(context)
    {
    }
}
