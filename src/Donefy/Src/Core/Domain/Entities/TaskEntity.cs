namespace Donefy.Src.Core.Domain.Entities;
public class TaskEntity : EntityBase, IAggregateRoot
{
    #region Properties
    public string Title { get; private set; } = string.Empty;
    public EStatus Status { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime? DeletedAt { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    #endregion

    #region Constructors
    public TaskEntity() {}
    #endregion

    #region Domain Methods
    public void Archive()
    {
        if (IsDeleted) return;
        
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Restore()
    {
        if (!IsDeleted) return;
        
        IsDeleted = false;
        DeletedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Update(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title == Title) return;
    
        Validate(title);
        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateStatus(EStatus newStatus)
    {
        if (Status == EStatus.Done)
            throw new InvalidOperationException("Cannot modify completed task");

        if (Status == EStatus.Cancelled && newStatus != EStatus.ToDo)
            throw new InvalidOperationException("Cancelled task can only be reopened");

        if (Status == newStatus) return;

        ValidateStatusTransition(newStatus);

        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }
    #endregion

    #region Validation Methods
    private void Validate(string title)
    {
        DomainValidationExceptions.When(string.IsNullOrWhiteSpace(title), "Task title is required");
        DomainValidationExceptions.When(title.Length > 40, "Task title cannot exceed 40 characters");
        DomainValidationExceptions.When(title.Length < 5, "Task title must be at least 5 characters long");
    }

    private void ValidateStatusTransition(EStatus newStatus)
    {
        var validTransitions = new Dictionary<EStatus, EStatus[]>
        {
            [EStatus.ToDo] = new[] { EStatus.InProgress, EStatus.Cancelled },
            [EStatus.InProgress] = new[] { EStatus.Done, EStatus.Cancelled, EStatus.ToDo },
            [EStatus.Cancelled] = new[] { EStatus.ToDo },
            [EStatus.Done] = Array.Empty<EStatus>()
        };

        if (!validTransitions[Status].Contains(newStatus))
            throw new InvalidOperationException($"Transition from {Status} to {newStatus} is not allowed");
    }
    #endregion
}