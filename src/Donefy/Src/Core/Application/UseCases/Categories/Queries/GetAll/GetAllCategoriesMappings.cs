namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetAll;
public static class GetAllCategoriesMappings
{
    public static GetAllCategoriesResponse MapToGetCategories (this CategoryEntity entity)
    {
        return new GetAllCategoriesResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    public static IEnumerable<GetAllCategoriesResponse> MapToGetCategories(this IEnumerable<CategoryEntity> response)
    {
        return response.Select(entity => entity.MapToGetCategories());
    }
}
