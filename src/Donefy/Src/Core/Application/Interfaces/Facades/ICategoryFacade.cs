namespace Donefy.Src.Core.Application.Interfaces.Facades;
public interface ICategoryFacade
{
    Task<CommandResult<bool>> Create(CreateCategoryCommand command, CancellationToken token);
    Task<CommandResult<bool>> Delete(DeleteCategoryCommand command, CancellationToken token);
    Task<CommandResult<bool>> Update(UpdateCategoryCommand command, CancellationToken token);
}
