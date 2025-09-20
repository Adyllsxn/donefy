namespace Donefy.Src.Core.Application.Modules;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        #region Facades
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        #endregion

        #region Validations
        #endregion

        #region UseCases
        #endregion

        return services;
    }
}
