namespace Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Text)
            .IsRequired(true)
            .HasMaxLength(1024);

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
    }
}
