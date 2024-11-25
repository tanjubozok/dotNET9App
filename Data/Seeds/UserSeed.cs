namespace Data.Seeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.PasswordHash, f => f.Random.Bytes(32)) // Sahte binary veri için rastgele byte dizisi
            .RuleFor(u => u.Picture, f => f.Internet.Avatar())
            .RuleFor(u => u.Description, f => f.Lorem.Sentence(10))
            .RuleFor(u => u.CreatedByName, f => f.Name.FullName())
            .RuleFor(u => u.ModifiedByName, f => f.Name.FullName())
            .RuleFor(u => u.CratedDate, f => f.Date.Past())
            .RuleFor(u => u.ModifiedDate, f => f.Date.Recent())
            .RuleFor(u => u.IsActive, f => f.Random.Bool())
            .RuleFor(u => u.IsDeleted, f => f.Random.Bool())
            .RuleFor(u => u.Note, f => f.Lorem.Sentence(5))
            .RuleFor(u => u.RoleId, f => f.Random.Number(1, 9)); // Rastgele RoleId

        var users = faker.Generate(20);

        builder.HasData(users);
    }
}