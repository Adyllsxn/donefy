namespace Donefy.Src.Core.Application.Modules;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        #region Facades
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        #endregion

        #region Validations
        services.AddValidatorsFromAssembly(typeof(CreateCategoryCommandValidator).Assembly);
        #endregion

        #region CQRS
        var assembly = typeof(ApplicationModule).Assembly;
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        #endregion

        return services;
    }
}
