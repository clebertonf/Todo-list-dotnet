using FluentAssertions;
using Todo.Domain.Validation;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Tests.DomainTests;

public class TaskDomainTests
{
    [Fact]
    public void CreateTask_WhithValidParameters_CreateValidTask()
    {
        Action action = () => new Task("Title test", "Description test", DateTime.Now, false);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateTask_WhithNegativeIdValue_DomainExceptionInvalidId()
    {
        var id = int.MinValue;
        Action action = () => new Task(id, "Title test", "Description test", DateTime.Now, false);
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(id)} cannot be less than zero.");
    }

    [Fact]
    public void CreateTask_WhithEmptyName_DomainExceptionInvalidName()
    {
        var title = string.Empty;
        Action action = () => new Task(title, "Description test", DateTime.Now, false);
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(title)} cannot be empty.");
    }
    
    [Fact]
    public void CreateTask_WhithEmptyDescription_DomainExceptionInvalidName()
    {
        var description = string.Empty;
        Action action = () => new Task("Title test", description, DateTime.Now, false);
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(description)} cannot be empty.");
    }
    
    [Fact]
    public void CreateTask_WhithInvalidDate_DomainExceptionInvalidName()
    {
        var dueDate = DateTime.Now.Subtract(TimeSpan.FromDays(2));
        Action action = () => new Task("Title test", "Description test", dueDate, false);
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(dueDate)} cannot be less than to DateTime.Today.");
    }
}