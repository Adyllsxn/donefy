namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetAll;
public static class GetAllTasksMappings
{
    public static GetAllTasksResponse MapToGetTasks (this TaskEntity entity)
    {
        return new GetAllTasksResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            Status = entity.Status
        };
    }
    public static IEnumerable<GetAllTasksResponse> MapToGetTasks(this IEnumerable<TaskEntity> response)
    {
        return response.Select(entity => entity.MapToGetTasks());
    }
}
