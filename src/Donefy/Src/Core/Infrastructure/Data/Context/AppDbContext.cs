namespace Donefy.Src.Core.Infrastructure.Data.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories {get; set; } = null!;
    public DbSet<TaskEntity> Tasks {get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
}
