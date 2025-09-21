namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
public static class UpdateCategoryMappings
{
    public static void ApplyUpdateTo(this UpdateCategoryCommand command, CategoryEntity entity)
    {
        entity.Update(
            command.Name
        );
    }
}
