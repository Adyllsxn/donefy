namespace Donefy.Src.Core.Application.Interfaces.Facades;
public interface ICategoryFacade
{
    Task<CommandResult<bool>> Handle(CreateCategoryCommand command, CancellationToken token);
}
