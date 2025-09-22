namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetById;
public class GetTaskByIdQueryHandler : IQueryHandler<GetTaskByIdQuery, QueryResult<GetTaskByIdResponse>>
{
    #region Dependencies and Constructor
    private readonly ITaskRepository _repository;
    private readonly IValidator<GetTaskByIdQuery> _validator;

    public GetTaskByIdQueryHandler(
        ITaskRepository repository,
        IValidator<GetTaskByIdQuery> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    #endregion

    #region Query Handler
    public async Task<QueryResult<GetTaskByIdResponse>> Handle(GetTaskByIdQuery query, CancellationToken token)
    {
        var validationResult = await _validator.ValidateAsync(query, token);
        if (!validationResult.IsValid)
        {
            return new QueryResult<GetTaskByIdResponse>(
                null,
                $"{MessageResult.Common.FluentValidation}: {string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))}",
                StatusCode.BadRequest
            );
        }
        try
        {
            var entity = await _repository.GetByIdAsync(query.Id, token);
            if (entity is null)
            {
                return new QueryResult<GetTaskByIdResponse>(
                    null,
                    MessageResult.Common.NotFound,
                    StatusCode.NotFound
                );
            }

            var response = entity.MapToGetTaskById();
            return new QueryResult<GetTaskByIdResponse>(
                data: response,
                message: MessageResult.Common.Success,
                code: StatusCode.OK
            );
        }
        catch (Exception ex)
        {
            return new QueryResult<GetTaskByIdResponse>(
                data: null,
                message: $"{MessageResult.Operation.ErrorGetById}. Erro: {ex.Message}",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}