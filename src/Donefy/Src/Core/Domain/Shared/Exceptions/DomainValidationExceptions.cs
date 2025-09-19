namespace Donefy.Src.Core.Domain.Shared.Exceptions;
public class DomainValidationExceptions : Exception
{
    public DomainValidationExceptions(string message) : base(message){}
    public static void When (bool condition, string message)
    {
        if(condition)
        {
            throw new DomainValidationExceptions(message);
        }
    }
}