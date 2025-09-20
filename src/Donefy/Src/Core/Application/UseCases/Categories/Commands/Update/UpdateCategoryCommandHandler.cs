namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, CommandResult<bool>>
{
    #region Dependencies and Constructor
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateCategoryCommand> _validator;

    public UpdateCategoryCommandHandler(
        ICategoryRepository repository,
        IUnitOfWork unitOfWork, 
        IValidator<UpdateCategoryCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    #endregion

    #region Command Handler
    public async Task<CommandResult<bool>> Handle(UpdateCategoryCommand command, CancellationToken token)
    {
        var validationResult = await _validator.ValidateAsync(command, token);
        if (!validationResult.IsValid)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"{MessageResult.Common.FluentValidation}: {string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))}",
                code: StatusCode.BadRequest
            );
        }

        try
        {
            var existingCategory = await _repository.GetByIdAsync(command.Id, token);
            if (existingCategory is null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: MessageResult.Common.NotFound,
                    code: StatusCode.NotFound
                );
            }

            command.ApplyUpdateTo(existingCategory);

            await _repository.UpdateAsync(existingCategory, token);
            await _unitOfWork.CommitAsync(token);

            return CommandResult<bool>.Success(
                value: true,
                message: MessageResult.Common.Success,
                code: StatusCode.OK
            );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"{MessageResult.Operation.ErrorUpdate}. Erro {ex.Message}.",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}