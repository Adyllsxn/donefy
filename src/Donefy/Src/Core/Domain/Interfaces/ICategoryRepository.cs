namespace Donefy.Src.Core.Domain.Interfaces;
public interface ICategoryRepository : ICategoryReadRepository, ICategoryWriteRepository { }

public interface ICategoryReadRepository
{
    Task<(List<CategoryEntity> Categories, int TotalCount)> GetAllAsync(PagedRequest request, CancellationToken token);
    Task<CategoryEntity?> GetByIdAsync(Guid categoryId, CancellationToken token);
}

public interface ICategoryWriteRepository  
{
    Task CreateAsync(CategoryEntity category, CancellationToken token);
    Task UpdateAsync(CategoryEntity category, CancellationToken token);
    Task DeleteAsync(Guid categoryId, CancellationToken token);
}