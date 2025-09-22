namespace Donefy.Src.Core.Application.Interfaces.Facades;
public interface ITaskFacade: ITaskCommandFacade, ITaskQueryFacade {}
public interface ITaskCommandFacade
{
    Task<CommandResult<bool>> Handle(CreateTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Handle(DeleteTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Handle(UpdateTaskCommand command, CancellationToken token);
    Task<CommandResult<bool>> Handle(StatusTaskCommand command, CancellationToken token);
}
public interface ITaskQueryFacade
{
    Task<PagedList<List<GetAllTasksResponse>>> Handle(GetAllTasksQuery query, CancellationToken token);
    Task<QueryResult<GetTaskByIdResponse>> Handle(GetTaskByIdQuery query, CancellationToken token);
}