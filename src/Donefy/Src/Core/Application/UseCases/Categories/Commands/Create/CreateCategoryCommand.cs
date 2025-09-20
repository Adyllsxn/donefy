namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Create;
public class CreateCategoryCommand: ICommand<CommandResult<bool>>
{
    public string Name { get; set; } = string.Empty;
}
