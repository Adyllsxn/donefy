namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
public class GetCategoryByIdQuery: IQuery<QueryResult<GetCategoryByIdResponse>>
{
    public Guid Id { get; set; }
}
