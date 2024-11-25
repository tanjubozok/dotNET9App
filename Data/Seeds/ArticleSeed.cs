namespace Data.Seeds;

public class ArticleSeed : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
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
