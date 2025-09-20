namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
public class GetCategoryByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
