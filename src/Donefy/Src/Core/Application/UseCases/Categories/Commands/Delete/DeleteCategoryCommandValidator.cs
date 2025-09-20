namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Delete;
public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");
    }
}