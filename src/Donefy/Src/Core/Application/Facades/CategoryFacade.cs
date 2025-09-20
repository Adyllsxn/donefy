namespace Donefy.Src.Core.Application.Facades;
public class CategoryFacade : ICategoryFacade
{
    #region Dependencies
    private readonly CreateCategoryCommandHandler _create;
    private readonly DeleteCategoryCommandHandler _delete;
    private readonly UpdateCategoryCommandHandler _update;
    public CategoryFacade(
        CreateCategoryCommandHandler create,
        DeleteCategoryCommandHandler delete,
        UpdateCategoryCommandHandler update)
    {
        _create = create;
        _delete = delete;
        _update = update;
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

    public async Task<CommandResult<bool>> Update(UpdateCategoryCommand command, CancellationToken token)
    {
        return await _update.Handle(command, token);
    }
    #endregion
}
