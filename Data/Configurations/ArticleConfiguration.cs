namespace Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(128);

        builder.Property(x => x.Content)
            .IsRequired(true)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Date)
            .IsRequired(true);

        builder.Property(x => x.SeoAuthor)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.SeoDescription)
            .IsRequired(true)
            .HasMaxLength(128);

        builder.Property(x => x.SeoTag)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.ViewsCount)
            .IsRequired(true);

        builder.Property(x => x.CommentCount)
            .IsRequired(true);

        builder.Property(x => x.Thumbnail)
            .IsRequired(true)
            .HasMaxLength(256);

        builder.Property(x => x.CreatedByName)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.ModifiedByName)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.CratedDate)
            .IsRequired(true);

        builder.Property(x => x.ModifiedDate)
            .IsRequired(false);

        builder.Property(x => x.IsActive)
            .IsRequired(true);

        builder.Property(x => x.IsDeleted)
            .IsRequired(true);

        builder.Property(x => x.Note)
            .IsRequired(false)
            .HasMaxLength(512);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Article)
            .HasForeignKey(x => x.ArticleId);

        var faker = new Faker<Article>()
            .RuleFor(a => a.Id, f => f.IndexFaker + 1)
            .RuleFor(a => a.Title, f => f.Lorem.Sentence(5))
            .RuleFor(a => a.Content, f => f.Lorem.Paragraphs(3))
            .RuleFor(a => a.Date, f => f.Date.Past(1)) // Geçmiş bir tarihte oluşturulmuş sahte makale tarihi
            .RuleFor(a => a.SeoAuthor, f => f.Name.FullName())
            .RuleFor(a => a.SeoDescription, f => f.Lorem.Sentence(10))
            .RuleFor(a => a.SeoTag, f => f.Lorem.Word())
            .RuleFor(a => a.ViewsCount, f => f.Random.Number(0, 10000))
            .RuleFor(a => a.CommentCount, f => f.Random.Number(0, 100))
            .RuleFor(a => a.Thumbnail, f => f.Image.PicsumUrl())
            .RuleFor(a => a.CreatedByName, f => f.Name.FullName())
            .RuleFor(a => a.ModifiedByName, f => f.Name.FullName())
            .RuleFor(a => a.CratedDate, f => f.Date.Past())
            .RuleFor(a => a.ModifiedDate, f => f.Date.Recent())
            .RuleFor(a => a.IsActive, f => f.Random.Bool())
            .RuleFor(a => a.IsDeleted, f => f.Random.Bool())
            .RuleFor(a => a.Note, f => f.Lorem.Sentence(5))
            .RuleFor(a => a.UserId, f => f.Random.Number(1, 20))
            .RuleFor(a => a.CategoryId, f => f.Random.Number(1, 20));

        var articles = faker.Generate(20);

        builder.HasData(articles);
    }
}