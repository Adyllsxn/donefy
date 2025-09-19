namespace Donefy.Src.Core.Infrastructure.Data.UoW;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken token)
    {
        await context.SaveChangesAsync(token);
    }

    public async Task RollbackAsync(CancellationToken token)
    {
        await context.Database.RollbackTransactionAsync(token);
    }
}
