namespace Data.Abstract;

public interface IUnitOfWork : IAsyncDisposable
{
    IArticleRepository ArticleRepository { get; }
    ICategoryReposiyory CategoryReposiyory { get; }
    ICommentRepository CommentRepository { get; }
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }

    Task<int> SaveAsync();
}
