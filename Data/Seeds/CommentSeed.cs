namespace Data.Seeds;

public class CommentSeed : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        var faker = new Faker<Comment>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Text, f => f.Lorem.Sentence(20))
            .RuleFor(c => c.CreatedByName, f => f.Name.FullName())
            .RuleFor(c => c.ModifiedByName, f => f.Name.FullName())
            .RuleFor(c => c.CratedDate, f => f.Date.Past())
            .RuleFor(c => c.ModifiedDate, f => f.Date.Recent())
            .RuleFor(c => c.IsActive, f => f.Random.Bool())
            .RuleFor(c => c.IsDeleted, f => f.Random.Bool())
            .RuleFor(c => c.Note, f => f.Lorem.Sentence(5))
            .RuleFor(c => c.ArticleId, c => c.Random.Number(1, 19));

        var comments = faker.Generate(50);
    }
}
