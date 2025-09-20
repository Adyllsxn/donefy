namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
public class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MinimumLength(5).WithMessage("Category name must be at least 5 characters long.")
            .MaximumLength(30).WithMessage("Category name cannot exceed 30 characters.");
    }
}
