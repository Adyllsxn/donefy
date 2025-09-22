namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Status;
public class StatusTaskCommandValidator: AbstractValidator<StatusTaskCommand>
{
    public StatusTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid Status.");
    }
}
