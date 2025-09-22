namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Create;
public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Task title is required")
            .MinimumLength(5).WithMessage("Task title must be at least 5 characters long")
            .MaximumLength(40).WithMessage("Task title cannot exceed 40 characters");
    }
}
