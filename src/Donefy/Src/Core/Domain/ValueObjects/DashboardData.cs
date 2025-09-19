namespace Donefy.Src.Core.Domain.ValueObjects;
public record DashboardData
{
    public int TotalTasks { get; init; }
    public int TotalCategories { get; init; }
    
    public static DashboardData Create(int tasks, int categories, int completed, int pending)
    {
        return new DashboardData
        {
            TotalTasks = tasks,
            TotalCategories = categories
        };
    }
}