namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Delete;
public class DeleteCategoryCommand: ICommand<CommandResult<bool>>
{
    public Guid Id { get; set; }
}
