namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Update;
public static class UpdateTaskMappings
{
    public static void ApplyUpdateTo(this UpdateTaskCommand command, TaskEntity entity)
    {
        entity.Update(
            command.Title
        );
    }
}
