namespace Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasMaxLength(64);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(512);

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

        builder.HasMany(x => x.Articles)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);

        var faker = new Faker<Category>()
           .RuleFor(c => c.Id, f => f.IndexFaker + 1)
           .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
           .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
           .RuleFor(c => c.CreatedByName, f => f.Name.FullName())
           .RuleFor(c => c.ModifiedByName, f => f.Name.FullName())
           .RuleFor(c => c.CratedDate, f => f.Date.Past())
           .RuleFor(c => c.ModifiedDate, f => f.Date.Recent())
           .RuleFor(c => c.IsActive, f => f.Random.Bool())
           .RuleFor(c => c.IsDeleted, f => f.Random.Bool())
           .RuleFor(c => c.Note, f => f.Lorem.Sentence(5));

        var categories = faker.Generate(20);

        builder.HasData(categories);
    }
}
