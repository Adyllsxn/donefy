namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Delete;
public class DeleteTaskCommandHandler: ICommandHandler<DeleteTaskCommand, CommandResult<bool>>
{
    #region Dependencies and Constructor
    private readonly ITaskRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteTaskCommand> _validator;

    public DeleteTaskCommandHandler(
        ITaskRepository repository,
        IUnitOfWork unitOfWork, 
        IValidator<DeleteTaskCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    #endregion

    #region Command Handler
    public async Task<CommandResult<bool>> Handle(DeleteTaskCommand command, CancellationToken token)
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
            var existingTask = await _repository.GetByIdAsync(command.Id, token);
            if (existingTask is null)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: MessageResult.Common.NotFound,
                    code: StatusCode.NotFound
                );
            }
            
            await _repository.DeleteAsync(command.Id, token);
            await _unitOfWork.CommitAsync(token);

            return CommandResult<bool>.Success(
                value: true,
                message: MessageResult.Common.Success,
                StatusCode.OK
            );
        }
        catch (Exception ex)
        {
            return CommandResult<bool>.Failure(
                value: false,
                message: $"{MessageResult.Operation.ErrorDelete}. Erro {ex.Message}.",
                code: StatusCode.InternalServerError
            );
        }
    }
    #endregion
}