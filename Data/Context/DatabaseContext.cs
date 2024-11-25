namespace Data.Context;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region configurations

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        #endregion

        #region seeds

        //modelBuilder.ApplyConfiguration(new RoleSeed());
        //modelBuilder.ApplyConfiguration(new UserSeed());
        //modelBuilder.ApplyConfiguration(new CategorySeed());
        //modelBuilder.ApplyConfiguration(new ArticleSeed());
        //modelBuilder.ApplyConfiguration(new CommentSeed());

        #endregion
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
}
