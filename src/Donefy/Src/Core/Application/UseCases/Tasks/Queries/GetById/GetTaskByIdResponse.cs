namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetById;
public class GetTaskByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public EStatus Status { get; set; }
}
