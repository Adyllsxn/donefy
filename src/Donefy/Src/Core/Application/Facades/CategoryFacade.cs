namespace Donefy.Src.Core.Application.Facades;
public class CategoryFacade : ICategoryFacade
{
    #region Dependencies
    private readonly CreateCategoryCommandHandler _create;
    public CategoryFacade(CreateCategoryCommandHandler create)
    {
        _create = create;
    }
    #endregion

    #region ICategoryFacade Implementation
    public async Task<CommandResult<bool>> Handle(CreateCategoryCommand command, CancellationToken token)
    {
        return await _create.Handle(command, token);
    }
    #endregion
}
