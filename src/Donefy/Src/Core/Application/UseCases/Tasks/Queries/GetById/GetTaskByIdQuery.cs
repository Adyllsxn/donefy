namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetById;
public class GetTaskByIdQuery: IQuery<QueryResult<GetTaskByIdResponse>>
{
    public Guid Id { get; set; }
}
