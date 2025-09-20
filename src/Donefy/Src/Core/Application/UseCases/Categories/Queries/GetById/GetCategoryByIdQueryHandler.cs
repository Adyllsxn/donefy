namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, QueryResult<GetCategoryByIdResponse>>
{
    #region Dependencies and Constructor
    private readonly ICategoryRepository _repository;
    private readonly IValidator<GetCategoryByIdQuery> _validator;

    public GetCategoryByIdQueryHandler(
        ICategoryRepository repository,
        IValidator<GetCategoryByIdQuery> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    #endregion

    #region Query Handler
    public async Task<QueryResult<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery query, CancellationToken token)
    {
        var validationResult = await _validator.ValidateAsync(query, token);
        if (!validationResult.IsValid)
        {
            return new QueryResult<GetCategoryByIdResponse>(
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
                return new QueryResult<GetCategoryByIdResponse>(
                    null,
                    MessageResult.Common.NotFound,
                    StatusCode.NotFound
                );
            }

            var response = entity.MapToGetCategoryById();
            return new QueryResult<GetCategoryByIdResponse>(
                data: response,
                message: MessageResult.Common.Success,
                code: StatusCode.OK
            );
        }
        catch (Exception ex)
        {
            return new QueryResult<GetCategoryByIdResponse>(
                data: null,
                message: $"{MessageResult.Operation.ErrorGetById}. Erro: {ex.Message}",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}