using FluentAssertions;
using Todo.Domain.Entities;
using Todo.Domain.Validation;

namespace Todo.Tests.DomainTests;

public class CategoryDomainTests
{
    [Fact]
    public void CreateCategory_WhithValidParams_CreateValidCategory()
    {
        Action action = () => new Category(1, "Category test", "Description test");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_WhithNegativeIdValue_DomainExceptionInvalidId()
    {
        var id = int.MinValue;
        Action action = () => new Category(id, "Category test", "Description test");
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(id)} cannot be less than zero.");
    }

    [Fact]
    public void CreateCategory_WhithEmptyName_DomainExceptionInvalidName()
    { 
        var name = string.Empty;
        Action action = () => new Category(1, name, "Description test");
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(name)} cannot be empty.");
    }
    
    [Fact]
    public void CreateCategory_WhithEmptyDescription_DomainExceptionInvalidDescription()
    {
        var description = string.Empty;
        Action action = () => new Category(1, "Category test", description);
        action.Should().Throw<DomainExceptionValidation>().WithMessage($"{nameof(description)} cannot be empty.");
    }
}