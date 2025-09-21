namespace Donefy.Src.Core.Infrastructure.Data.Mappings;
public class CategoryMapping : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);


        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnType("VARCHAR(30)");
        builder.HasIndex(x => x.Name)
               .IsUnique()
               .HasFilter("\"IsDeleted\" = false"); 

        builder.Property(x => x.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(x => x.DeletedAt)
               .HasColumnType("TIMESTAMP")
               .IsRequired(false);

        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasColumnType("TIMESTAMP")
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
               .IsRequired()
               .HasColumnType("TIMESTAMP")
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}