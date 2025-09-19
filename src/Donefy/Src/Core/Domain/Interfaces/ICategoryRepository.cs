namespace Donefy.Src.Core.Domain.Interfaces;
public interface ICategoryRepository
{
    Task<(List<CategoryEntity> Result, int Total)> GetAllAsync(PagedRequest request, CancellationToken token);
    Task<CategoryEntity?> GetByIdAsync(Guid entityId, CancellationToken token);
    Task CreateAsync(CategoryEntity entity, CancellationToken token);
    Task DeleteAsync(Guid entityId, CancellationToken token);
    Task UpdateAsync(CategoryEntity entity, CancellationToken token);
}
