namespace Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

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

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId);
    }
}
