namespace Donefy.Src.Core.Infrastructure.Data.Mappings;
public class TaskMapping : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(40)
               .HasColumnType("VARCHAR(40)");
        
        builder.Property(x => x.Status)
               .IsRequired()
               .HasColumnType("INTEGER")
               .HasConversion<int>()
               .HasDefaultValue(EStatus.ToDo);
        
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
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .ValueGeneratedOnUpdate();

        builder.HasIndex(x => x.Title);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.IsDeleted);
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}