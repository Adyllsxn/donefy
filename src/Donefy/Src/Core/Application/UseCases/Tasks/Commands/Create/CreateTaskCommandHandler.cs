namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Create;
public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand, CommandResult<bool>>
{
    #region Dependencies and Constructor
    private readonly ITaskRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateTaskCommand> _validator;
    public CreateTaskCommandHandler(
        ITaskRepository repository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateTaskCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    #endregion

    #region Command Handler
    public async Task<CommandResult<bool>> Handle(CreateTaskCommand command, CancellationToken token)
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
            var entity = command.MapToTaskEntity();
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
