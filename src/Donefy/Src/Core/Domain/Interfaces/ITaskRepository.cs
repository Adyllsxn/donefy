namespace Donefy.Src.Core.Domain.Interfaces;
public interface ITaskRepository : ITaskReadRepository, ITaskWriteRepository { }

public interface ITaskReadRepository
{
    Task<(List<TaskEntity> Tasks, int TotalCount)> GetAllAsync(PagedRequest request, CancellationToken token);
    Task<TaskEntity?> GetByIdAsync(Guid taskId, CancellationToken token);
}

public interface ITaskWriteRepository  
{
    Task<bool> CreateAsync(TaskEntity task, CancellationToken token);
    Task<bool> UpdateAsync(TaskEntity task, CancellationToken token);
    Task<bool> DeleteAsync(Guid taskId, CancellationToken token);
    Task<bool> UpdateStatusAsync(Guid taskId, EStatus newStatus, CancellationToken token);
}