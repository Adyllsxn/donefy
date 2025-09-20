namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
public static class GetCategoryByIdMappings
{
    public static GetCategoryByIdResponse MapToGetCategoryById (this CategoryEntity entity)
    {
        return new GetCategoryByIdResponse
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    public static IEnumerable<GetCategoryByIdResponse> MapToGetCategoryById(this IEnumerable<CategoryEntity> response)
    {
        return response.Select(entity => entity.MapToGetCategoryById());
    }
}
