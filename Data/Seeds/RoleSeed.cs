namespace Data.Seeds;

public class RoleSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        var faker = new Faker<Role>()
            .RuleFor(r => r.Id, f => f.IndexFaker + 1)
            .RuleFor(r => r.Name, f => f.Name.JobTitle())
            .RuleFor(r => r.Description, f => f.Lorem.Sentence(5))
            .RuleFor(r => r.CreatedByName, f => f.Name.FullName())
            .RuleFor(r => r.ModifiedByName, f => f.Name.FullName())
            .RuleFor(r => r.CratedDate, f => f.Date.Past())
            .RuleFor(r => r.ModifiedDate, f => f.Date.Recent())
            .RuleFor(r => r.IsActive, f => f.Random.Bool())
            .RuleFor(r => r.IsDeleted, f => f.Random.Bool())
            .RuleFor(r => r.Note, f => f.Lorem.Sentence(10));

        var roles = faker.Generate(10);

        builder.HasData(roles);
    }
}