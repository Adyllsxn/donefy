namespace Donefy.Src.Core.Infrastructure.Data.Repositories;
public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    #region Create
    public async Task CreateAsync(CategoryEntity entity, CancellationToken token)
    {
        await context.Categories.AddAsync(entity, token);
    }
    #endregion

    #region Delete
    public async Task DeleteAsync(Guid entityId, CancellationToken token)
    {
        var entity = await context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == entityId, token);
        if (entity is null)
            throw new KeyNotFoundException("Category not found.");

        entity.Archive();
        context.Categories.Update(entity);
    }
    #endregion

    #region GetAll
    public async Task<(List<CategoryEntity> Result, int Total)> GetAllAsync(PagedRequest request, CancellationToken token)
    {
        var query = context.Categories
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Name)
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
    public async Task<CategoryEntity?> GetByIdAsync(Guid entityId, CancellationToken token)
    {
        var entity = await context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == entityId, token);
        return entity;
    }
    #endregion

    #region Update
    public async Task UpdateAsync(CategoryEntity entity, CancellationToken token)
    {
        var existing = await context.Categories
            .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == entity.Id, token);

        if (existing != null)
        {
            existing.Update(entity.Name);
            context.Entry(existing).CurrentValues.SetValues(entity);
        }
    }
    #endregion
}
