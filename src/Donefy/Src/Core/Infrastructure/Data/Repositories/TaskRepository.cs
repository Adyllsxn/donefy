namespace Donefy.Src.Core.Infrastructure.Data.Repositories;
public class TaskRepository(AppDbContext context) : ITaskRepository
{
    #region Create
    public async Task CreateAsync(TaskEntity task, CancellationToken token)
    {
        await context.Tasks.AddAsync(task, token);
    }
    #endregion

    #region Delete
    public async Task DeleteAsync(Guid taskId, CancellationToken token)
    {
        var entity = await context.Tasks.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == taskId, token);
        if (entity is null)
            throw new KeyNotFoundException("Category not found.");

        entity.Archive();
        context.Tasks.Update(entity);
    }
    #endregion

    #region GetAll
    public async Task<(List<TaskEntity> Tasks, int TotalCount)> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        var query = context.Tasks
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Title)
                    .AsQueryable();

        var items = await query
                    .Skip(request.Skip)
                    .Take(request.Take)
                    .ToListAsync(token);

        var totalCount = await query.CountAsync(token);

        return (items, totalCount);
    }
    #endregion

    #region GetById
    public async Task<TaskEntity?> GetByIdAsync(Guid taskId, CancellationToken token)
    {
        var entity = await context.Tasks.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == taskId, token);
        return entity;
    }
    #endregion

    #region Update
    public async Task UpdateAsync(TaskEntity task, CancellationToken token)
    {
        var existing = await context.Tasks
            .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == task.Id, token);

        if (existing != null)
        {
            existing.Update(task.Title);
            context.Entry(existing).CurrentValues.SetValues(task);
        }
    }
    #endregion

    #region UpdateStatus
    public async Task UpdateStatusAsync(Guid taskId, EStatus newStatus, CancellationToken token)
    {
        var entity = await context.Tasks
            .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == taskId, token);

        if (entity is null) return;

        entity.UpdateStatus(newStatus);

        context.Tasks.Update(entity);
    }
    #endregion
}
