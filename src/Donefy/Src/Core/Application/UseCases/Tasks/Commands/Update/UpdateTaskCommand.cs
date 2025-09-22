namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Update;
public class UpdateTaskCommand:  ICommand<CommandResult<bool>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
