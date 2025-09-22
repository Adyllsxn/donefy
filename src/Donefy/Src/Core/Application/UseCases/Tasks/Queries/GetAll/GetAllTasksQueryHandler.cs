namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetAll;
public class GetAllTasksQueryHandler : IQueryHandler<GetAllTasksQuery, PagedList<List<GetAllTasksResponse>>>
{
    #region Dependencies and Constructor
    private readonly ITaskRepository _repository;

    public GetAllTasksQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }
    #endregion

    #region Query Handler
    public async Task<PagedList<List<GetAllTasksResponse>>> Handle(GetAllTasksQuery query, CancellationToken token)
    {
        try
        {
            var (entities, total) = await _repository.GetAllAsync(query, token);

            if (entities == null || entities.Count == 0)
            {
                return new PagedList<List<GetAllTasksResponse>>(
                    data: null,
                    message: MessageResult.Common.NotFound,
                    code: StatusCode.NotFound
                );
            }

            var responseList = entities.MapToGetTasks().ToList();

            return new PagedList<List<GetAllTasksResponse>>(
                data: responseList,
                totalCount: total,
                currentPage: query.PageNumber,
                pageSize: query.PageSize
            );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetAllTasksResponse>>(
                data: null,
                message: $"{MessageResult.Operation.ErrorGetAll}. Erro: {ex.Message}",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}