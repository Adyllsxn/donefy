namespace Donefy.Src.Core.Application.UseCases.Tasks.Commands.Update;
public class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand, CommandResult<bool>>
{
    #region Dependencies and Constructor
    private readonly ITaskRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateTaskCommand> _validator;

    public UpdateTaskCommandHandler(
        ITaskRepository repository,
        IUnitOfWork unitOfWork, 
        IValidator<UpdateTaskCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    #endregion

    #region Command Handler
    public async Task<CommandResult<bool>> Handle(UpdateTaskCommand command, CancellationToken token)
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

            command.ApplyUpdateTo(existingTask);

            await _repository.UpdateAsync(existingTask, token);
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