namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Delete;
public class DeleteTaskCommand: ICommand<CommandResult<bool>>
{
    public Guid Id { get; set; }
}
