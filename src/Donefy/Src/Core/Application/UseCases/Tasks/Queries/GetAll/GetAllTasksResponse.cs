namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetAll;
public class GetAllTasksResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public EStatus Status { get; set; }
}
