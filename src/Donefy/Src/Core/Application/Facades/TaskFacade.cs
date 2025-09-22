namespace Donefy.Src.Core.Application.Facades;
public class TaskFacade : ITaskFacade
{
    #region Dependencies and Constructor
    private readonly CreateTaskCommandHandler _create;
    private readonly DeleteTaskCommandHandler _delete;
    private readonly UpdateTaskCommandHandler _update;
    private readonly StatusTaskCommandHandler _status;
    private readonly GetAllTasksQueryHandler _getAll;
    private readonly GetTaskByIdQueryHandler _getById;
    
    public TaskFacade(
        CreateTaskCommandHandler create,
        DeleteTaskCommandHandler delete,
        UpdateTaskCommandHandler update,
        StatusTaskCommandHandler status,
        GetAllTasksQueryHandler getAll,
        GetTaskByIdQueryHandler getById)
    {
        _create = create;
        _status = status;
        _delete = delete;
        _update = update;
        _getAll = getAll;
        _getById = getById;
    }
    #endregion

    #region ITaskFacade Implementation
    public async Task<CommandResult<bool>> Handle(CreateTaskCommand command, CancellationToken token) => await _create.Handle(command, token);

    public async Task<CommandResult<bool>> Handle(DeleteTaskCommand command, CancellationToken token) => await _delete.Handle(command, token);

    public async Task<CommandResult<bool>> Handle(UpdateTaskCommand command, CancellationToken token) => await _update.Handle(command, token);

    public async Task<CommandResult<bool>> Handle(StatusTaskCommand command, CancellationToken token) => await _status.Handle(command, token);

    public async Task<PagedList<List<GetAllTasksResponse>>> Handle(GetAllTasksQuery query, CancellationToken token) => await _getAll.Handle(query, token);

    public async Task<QueryResult<GetTaskByIdResponse>> Handle(GetTaskByIdQuery query, CancellationToken token) => await _getById.Handle(query, token);
    #endregion
}
