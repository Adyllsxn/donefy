namespace Donefy.Src.Core.Application.Interfaces.Facades;
public interface ITaskFacade: ITaskCommandFacade, ITaskQueryFacade {}
public interface ITaskCommandFacade
{
    Task<CommandResult<bool>> Create(CreateTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Delete(DeleteTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Update(UpdateTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Status(StatusTaskCommand command, CancellationToken token);
}
public interface ITaskQueryFacade
{
    Task<PagedList<List<GetAllTasksResponse>>> GetAll(GetAllTasksQuery query, CancellationToken token);
    Task<QueryResult<GetTaskByIdResponse>> GetById(GetTaskByIdQuery query, CancellationToken token);
}