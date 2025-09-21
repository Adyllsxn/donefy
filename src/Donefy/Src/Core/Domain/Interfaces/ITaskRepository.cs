namespace Donefy.Src.Core.Domain.Interfaces;
public interface ITaskRepository : ITaskReadRepository, ITaskWriteRepository { }

public interface ITaskReadRepository
{
    Task<(List<TaskEntity> Tasks, int TotalCount)> GetAllAsync(PagedRequest request, CancellationToken token);
    Task<TaskEntity?> GetByIdAsync(Guid taskId, CancellationToken token);
}

public interface ITaskWriteRepository  
{
    Task CreateAsync(TaskEntity task, CancellationToken token);
    Task UpdateAsync(TaskEntity task, CancellationToken token);
    Task DeleteAsync(Guid taskId, CancellationToken token);
    Task UpdateStatusAsync(Guid taskId, EStatus newStatus, CancellationToken token);
}