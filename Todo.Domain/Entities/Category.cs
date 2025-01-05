using Todo.Domain.Validation;

namespace Todo.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<Task> Tasks { get; set; }

    public Category(string name, string description)
    {
        ValidateDomain(name, description);
    }

    public Category(int id, string name, string description)
    {
        DomainExceptionValidation.When(id <= 0, $"{nameof(id)} cannot be less than zero.");
        ValidateDomain(name, description);
        Id = id;
    }

    private void ValidateDomain(string name, string description)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
            $"{nameof(name)} cannot be empty.");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
            $"{nameof(description)} cannot be empty.");
        
        Name = name;
        Description = description;
    }
}