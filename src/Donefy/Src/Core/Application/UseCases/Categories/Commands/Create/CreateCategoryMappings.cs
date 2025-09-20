namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Create;
public static class CreateCategoryMappings
{
    public static CategoryEntity MapToCategoryEntity(this CreateCategoryCommand command)
    {
        return new CategoryEntity(
            command.Name
        );
    }
}
