namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Status;
public class StatusTaskCommand: ICommand<CommandResult<bool>>
{
    public Guid Id { get; set; }
    public EStatus Status { get; set; }
}
