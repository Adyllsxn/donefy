namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Update;
public class UpdateTaskCommandValidator: AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Task title is required")
            .MinimumLength(5).WithMessage("Task title must be at least 5 characters long")
            .MaximumLength(40).WithMessage("Task title cannot exceed 40 characters");
    }
}
