namespace Data.UnitOfWorks;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    private readonly DatabaseContext _context = context;

    private ArticleRepository? _articleRepository;
    private CategoryRepsoitory? _categoryRepsoitory;
    private CommentRepository? _commentRepository;
    private RoleRepository? _roleRepository;
    private UserRepository? _userRepository;

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
