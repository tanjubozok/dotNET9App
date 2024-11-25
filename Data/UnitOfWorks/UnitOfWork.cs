namespace Data.UnitOfWorks;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    private readonly DatabaseContext _context = context;

    private readonly ArticleRepository? _articleRepository;
    private readonly CategoryRepsoitory? _categoryRepsoitory;
    private readonly CommentRepository? _commentRepository;
    private readonly RoleRepository? _roleRepository;
    private readonly UserRepository? _userRepository;

    public IArticleRepository ArticleRepository
        => _articleRepository
        ?? new ArticleRepository(_context);

    public ICategoryReposiyory CategoryReposiyory
        => _categoryRepsoitory
        ?? new CategoryRepsoitory(_context);

    public ICommentRepository CommentRepository
        => _commentRepository
        ?? new CommentRepository(_context);

    public IRoleRepository RoleRepository
        => _roleRepository
        ?? new RoleRepository(_context);

    public IUserRepository UserRepository
        => _userRepository
        ?? new UserRepository(_context);

    public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
}
