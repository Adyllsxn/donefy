namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Status;
public static class StatusTaskMappings
{
    public static void ApplyUpdateStatusTo(this StatusTaskCommand command, TaskEntity entity)
    {
        entity.UpdateStatus(
            command.Status
        );
    }
}
