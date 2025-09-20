namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
public class UpdateCategoryCommand:  ICommand<CommandResult<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
