namespace Donefy.Src.Core.Infrastructure.Data.Repositories;
public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    #region Create
    public async Task CreateAsync(CategoryEntity category, CancellationToken token)
    {
        await context.Categories.AddAsync(category, token);
    }
    #endregion

    #region Delete
    public async Task DeleteAsync(Guid categoryId, CancellationToken token)
    {
        var entity = await context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == categoryId, token);
        if (entity is null)
            throw new KeyNotFoundException("Category not found.");

        entity.Archive();
        context.Categories.Update(entity);
    }
    #endregion

    #region GetAll
    public async Task<(List<CategoryEntity> Categories, int TotalCount)> GetAllAsync(PagedRequest request, CancellationToken token)
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
    public async Task<CategoryEntity?> GetByIdAsync(Guid categoryId, CancellationToken token)
    {
        var entity = await context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == categoryId, token);
        return entity;
    }
    #endregion

    #region Update
    public async Task UpdateAsync(CategoryEntity category, CancellationToken token)
    {
        var existing = await context.Categories
            .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == category.Id, token);

        if (existing != null)
        {
            existing.Update(category.Name);
            context.Entry(existing).CurrentValues.SetValues(category);
        }
    }
    #endregion
}
