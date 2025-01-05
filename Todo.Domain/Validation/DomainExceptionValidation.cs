namespace Todo.Domain.Validation;

public class DomainExceptionValidation(string error) : Exception(error)
{
    public static void When(bool condition, string error)
    {
        if (condition)
        {
            throw new DomainExceptionValidation(error);
        }
    }
}