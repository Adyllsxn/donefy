namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Create;
public class CreateTaskCommand: ICommand<CommandResult<bool>>
{
    public string Title { get; set; } = string.Empty;
}
