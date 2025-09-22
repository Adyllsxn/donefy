namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetById;
public static class GetTaskByIdMappings
{
    public static GetTaskByIdResponse MapToGetTaskById (this TaskEntity entity)
    {
        return new GetTaskByIdResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            Status = entity.Status
        };
    }
    public static IEnumerable<GetTaskByIdResponse> MapToGetTaskById(this IEnumerable<TaskEntity> response)
    {
        return response.Select(entity => entity.MapToGetTaskById());
    }
}
