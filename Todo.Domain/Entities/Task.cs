using Todo.Domain.Validation;

namespace Todo.Domain.Entities;

public sealed class Task : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsCompleted { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Task(string title, string description, DateTime dueDate, bool isCompleted)
    {
        ValidateDomain(title, description, dueDate, isCompleted: false);
    }
    
    public Task(int id, string title, string description, DateTime dueDate, bool isCompleted)
    {
        ValidateDomain(title, description, dueDate, isCompleted: false);
       //  DomainExceptionValidation.When(id <= 0, $"{nameof(id)} cannot be less than zero.");
        Id = id;
    }

    private void ValidateDomain(string title, string description, DateTime dueDate, bool isCompleted)
    {
        DomainExceptionValidation.When(title.Length <= 0, 
            $"{nameof(title)} cannot be empty.");
        DomainExceptionValidation.When(description.Length <= 0, 
            $"{nameof(description)} cannot be empty.");
        DomainExceptionValidation.When(dueDate.Date < DateTime.Today,
            $"{nameof(dueDate)} cannot be less than to DateTime.Today.");
        
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
}