namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Delete;
public class DeleteTaskCommandValidator: AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");
    }
}