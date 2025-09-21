namespace Donefy.Src.Core.Application.Modules;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        #region Facades
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ITaskFacade, TaskFacade>();
        #endregion

        #region Validations
        services.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
        #endregion

        #region CQRS
        var assembly = typeof(ApplicationModule).Assembly;
        
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        #endregion

        return services;
    }
}
