namespace Donefy.Src.Core.Application.UseCases.Categories.Commands.Create;
public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CommandResult<bool>>
{
    #region Dependencies
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCategoryCommand> _validator;

    public CreateCategoryCommandHandler(
        ICategoryRepository repository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateCategoryCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    #endregion

    #region Command Handler
    public async Task<CommandResult<bool>> Handle(CreateCategoryCommand command, CancellationToken token)
    {
        var result = await _validator.ValidateAsync(command, token);
        if (!result.IsValid)
        {
            return CommandResult<bool>.Failure(
                false, 
                $"{MessageResult.Common.FluentValidation}: {string.Join("; ", result.Errors.Select(e => e.ErrorMessage))}", 
                StatusCode.BadRequest
            );
        }
        
        try
        {
            var entity = command.MapToCategoryEntity();
            await _repository.CreateAsync(entity, token); 
            await _unitOfWork.CommitAsync(token);

            return CommandResult<bool>.Success(
                value: true,
                message: MessageResult.Common.Success,
                code: StatusCode.OK
            );
        }
        catch(Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"{MessageResult.Operation.ErrorCreate} Error {ex.Message}.",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}