namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetAll;
public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, PagedList<List<GetAllCategoriesResponse>>>
{
    #region Dependencies
    private readonly ICategoryRepository _repository;

    public GetAllCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    #endregion

    #region Query Handler
    public async Task<PagedList<List<GetAllCategoriesResponse>>> Handle(GetAllCategoriesQuery query, CancellationToken token)
    {
        try
        {
            var (entities, total) = await _repository.GetAllAsync(query, token);

            if (entities == null || entities.Count == 0)
            {
                return new PagedList<List<GetAllCategoriesResponse>>(
                    data: null,
                    message: MessageResult.Common.NotFound,
                    code: StatusCode.NotFound
                );
            }

            var responseList = entities.MapToGetCategories().ToList();

            return new PagedList<List<GetAllCategoriesResponse>>(
                data: responseList,
                totalCount: total,
                currentPage: query.PageNumber,
                pageSize: query.PageSize
            );
        }
        catch (Exception ex)
        {
            return new PagedList<List<GetAllCategoriesResponse>>(
                data: null,
                message: $"{MessageResult.Operation.ErrorGetAll}. Erro: {ex.Message}",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}