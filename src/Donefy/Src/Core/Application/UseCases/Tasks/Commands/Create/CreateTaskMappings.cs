namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Create;
public static class CreateTaskMappings
{
    public static TaskEntity MapToTaskEntity(this CreateTaskCommand command)
    {
        return new TaskEntity(
            command.Title
        );
    }
}
