namespace Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
public class GetCategoryByIdQueryValidator: AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid ID");
    }
}
