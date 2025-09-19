namespace Donefy.Src.Core.Domain.Interfaces;
public interface IDashboardRepository
{
    Task<DashboardData> GetDashboardDataAsync(CancellationToken cancellationToken);
}
