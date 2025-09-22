namespace Donefy.Src.Core.Domain.Entities;
public sealed class CategoryEntity: EntityBase, IAggregateRoot
{
    #region Properties
    public string Name { get; private set; } = string.Empty;
    public bool IsDeleted { get; private set; } = false;
    public DateTime? DeletedAt { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    #endregion

    #region Constructors 
    [JsonConstructor]
    public CategoryEntity(){}
    public CategoryEntity(string name)
    {
        Validate(name);
        Name = name;
    }
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
    public void Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name == Name) return;
    
        Validate(name);
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
    #endregion

    #region Validation Methods
    private void Validate(string name)
    {
        DomainValidationExceptions.When(string.IsNullOrWhiteSpace(name), "Category name is required.");
        DomainValidationExceptions.When(name.Length > 30, "Category name cannot exceed 30 characters.");
        DomainValidationExceptions.When(name.Length < 5, "Category name must be at least 5 characters long.");
    }
    #endregion
}
