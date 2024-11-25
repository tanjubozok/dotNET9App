namespace Data.Seeds;

public class DatabaseSeeder
{
    private readonly DatabaseContext _context;

    public DatabaseSeeder(DatabaseContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!await _context.Roles.AnyAsync())
        {
            var roles = new Faker<Role>()
                .RuleFor(r => r.Id, f => f.IndexFaker + 1)
                .RuleFor(r => r.Name, f => f.Commerce.Department())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence())
                .RuleFor(r => r.CreatedByName, f => f.Name.FullName())
                .RuleFor(r => r.ModifiedByName, f => f.Name.FullName())
                .RuleFor(r => r.CratedDate, f => f.Date.Past())
                .RuleFor(r => r.ModifiedDate, f => f.Date.Recent())
                .RuleFor(r => r.IsActive, f => f.Random.Bool())
                .RuleFor(r => r.IsDeleted, f => f.Random.Bool())
                .RuleFor(r => r.Note, f => f.Lorem.Sentence())
                .Generate(5);

            await _context.Roles.AddRangeAsync(roles);
        }

        if (!await _context.Users.AnyAsync())
        {
            var users = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.PasswordHash, f => f.Random.Bytes(32))
                .RuleFor(u => u.CreatedByName, f => f.Name.FullName())
                .RuleFor(u => u.ModifiedByName, f => f.Name.FullName())
                .RuleFor(u => u.CratedDate, f => f.Date.Past())
                .RuleFor(u => u.IsActive, f => f.Random.Bool())
                .RuleFor(u => u.IsDeleted, f => f.Random.Bool())
                .RuleFor(u => u.Note, f => f.Lorem.Sentence())
                .Generate(10);

            await _context.Users.AddRangeAsync(users);
        }

        if (!await _context.Categories.AnyAsync())
        {
            var categories = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.CreatedByName, f => f.Name.FullName())
                .RuleFor(c => c.ModifiedByName, f => f.Name.FullName())
                .RuleFor(c => c.CratedDate, f => f.Date.Past())
                .RuleFor(c => c.IsActive, f => f.Random.Bool())
                .RuleFor(c => c.IsDeleted, f => f.Random.Bool())
                .RuleFor(c => c.Note, f => f.Lorem.Sentence())
                .Generate(5);

            await _context.Categories.AddRangeAsync(categories);
        }

        if (!await _context.Articles.AnyAsync())
        {
            var articles = new Faker<Article>()
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Title, f => f.Lorem.Sentence(5))
                .RuleFor(a => a.Content, f => f.Lorem.Paragraphs(2))
                .RuleFor(a => a.SeoAuthor, f => f.Name.FullName())
                .RuleFor(a => a.SeoDescription, f => f.Lorem.Sentence())
                .RuleFor(a => a.SeoTag, f => f.Lorem.Word())
                .RuleFor(a => a.ViewsCount, f => f.Random.Number(0, 1000))
                .RuleFor(a => a.CommentCount, f => f.Random.Number(0, 100))
                .RuleFor(a => a.CreatedByName, f => f.Name.FullName())
                .RuleFor(a => a.ModifiedByName, f => f.Name.FullName())
                .RuleFor(a => a.CratedDate, f => f.Date.Past())
                .RuleFor(a => a.IsActive, f => f.Random.Bool())
                .RuleFor(a => a.IsDeleted, f => f.Random.Bool())
                .RuleFor(a => a.Note, f => f.Lorem.Sentence())
                .Generate(10);

            await _context.Articles.AddRangeAsync(articles);
        }

        if (!await _context.Comments.AnyAsync())
        {
            var comments = new Faker<Comment>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Text, f => f.Lorem.Sentence(20))
                .RuleFor(c => c.CreatedByName, f => f.Name.FullName())
                .RuleFor(c => c.ModifiedByName, f => f.Name.FullName())
                .RuleFor(c => c.CratedDate, f => f.Date.Past())
                .RuleFor(c => c.IsActive, f => f.Random.Bool())
                .RuleFor(c => c.IsDeleted, f => f.Random.Bool())
                .RuleFor(c => c.Note, f => f.Lorem.Sentence())
                .Generate(15);

            await _context.Comments.AddRangeAsync(comments);
        }

        await _context.SaveChangesAsync();
    }
}