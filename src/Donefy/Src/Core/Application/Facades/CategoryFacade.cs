
namespace Donefy.Src.Core.Application.Facades;
public class CategoryFacade : ICategoryFacade
{
    #region Dependencies
    private readonly CreateCategoryCommandHandler _create;
    private readonly DeleteCategoryCommandHandler _delete;
    private readonly UpdateCategoryCommandHandler _update;
    private readonly GetAllCategoriesQueryHandler _getAll;
    private readonly GetCategoryByIdQueryHandler _getById;
    public CategoryFacade(
        CreateCategoryCommandHandler create,
        DeleteCategoryCommandHandler delete,
        UpdateCategoryCommandHandler update,
        GetAllCategoriesQueryHandler getAll,
        GetCategoryByIdQueryHandler getById)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _getAll = getAll;
        _getById = getById;
    }
    #endregion

    #region ICategoryFacade Implementation
    public async Task<CommandResult<bool>> Create(CreateCategoryCommand command, CancellationToken token)
    {
        return await _create.Handle(command, token);
    }

    public async Task<CommandResult<bool>> Delete(DeleteCategoryCommand command, CancellationToken token)
    {
        return await _delete.Handle(command, token);
    }

    public async Task<PagedList<List<GetAllCategoriesResponse>>> GetAll(GetAllCategoriesQuery query, CancellationToken token)
    {
        return await _getAll.Handle(query, token);
    }

    public async Task<QueryResult<GetCategoryByIdResponse>> GetById(GetCategoryByIdQuery query, CancellationToken token)
    {
        return await _getById.Handle(query, token);
    }

    public async Task<CommandResult<bool>> Update(UpdateCategoryCommand command, CancellationToken token)
    {
        return await _update.Handle(command, token);
    }
    #endregion
}
