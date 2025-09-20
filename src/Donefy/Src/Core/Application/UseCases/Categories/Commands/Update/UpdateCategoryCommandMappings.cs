namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
public static class UpdateCategoryCommandMappings
{
    public static void ApplyUpdateTo(this UpdateCategoryCommand command, CategoryEntity entity)
    {
        entity.Update(
            command.Name
        );
    }
}
