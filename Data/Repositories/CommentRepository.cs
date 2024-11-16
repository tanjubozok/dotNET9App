using Data.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Concrete;

namespace Data.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(DbContext context) : base(context)
    {
    }
}
