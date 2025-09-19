namespace Donefy.Src.Core.Infrastructure.Modules;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastruture (this IServiceCollection services, IConfiguration configuration)
    {
        #region Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        #endregion

        #region Services
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region DbConnection
        var connectionDb = configuration.GetConnectionString(DbConnectionNames.PostgreSQL);
        services.AddDbContext<AppDbContext>(opt =>{
            opt.UseNpgsql(connectionDb,
            migration => migration.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        });
        #endregion

        return services;
    }
}
