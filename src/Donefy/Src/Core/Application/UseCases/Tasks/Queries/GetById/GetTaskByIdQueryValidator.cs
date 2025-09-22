namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetById;
public class GetTaskByIdQueryValidator: AbstractValidator<GetTaskByIdQuery>
{
    public GetTaskByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");
    }
}
