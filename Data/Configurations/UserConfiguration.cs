namespace Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.FirstName)
            .IsRequired(false)
            .HasMaxLength(64);

        builder.Property(x => x.LastName)
            .IsRequired(false)
            .HasMaxLength(64);

        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasMaxLength(128)
            .IsUnicode(true);

        builder.Property(x => x.Username)
            .IsRequired(true)
            .HasMaxLength(64)
            .IsUnicode(true);

        builder.Property(x => x.PasswordHash)
            .IsRequired(true)
            .HasColumnType("varbinary(32)");

        builder.Property(x => x.Picture)
            .IsRequired(false)
            .HasMaxLength(512);

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
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}
