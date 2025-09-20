namespace Donefy.Src.Core.Domain.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token);
}
