namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Create;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MinimumLength(5).WithMessage("Category name must be at least 5 characters long.")
            .MaximumLength(30).WithMessage("Category name cannot exceed 30 characters.");
    }
}