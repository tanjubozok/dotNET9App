﻿namespace Data.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(DbContext context) : base(context)
    {
    }
}
