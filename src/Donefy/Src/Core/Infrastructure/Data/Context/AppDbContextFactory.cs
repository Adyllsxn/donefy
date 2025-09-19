namespace Donefy.Src.Core.Infrastructure.Data.Context;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "❌ Database connection string not configured. " +
                "Please set the CONNECTION_STRING environment variable. " +
                "Use 'export CONNECTION_STRING=your_connection_string'."
            );
        }

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString, x => 
                x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            .Options;

        Console.WriteLine("✅ Database context configured successfully");
        return new AppDbContext(options);
    }
}
