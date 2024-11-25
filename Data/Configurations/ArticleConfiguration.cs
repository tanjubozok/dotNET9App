namespace Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

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
            .HasForeignKey(x => x.Id);
    }
}