namespace Data.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
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
