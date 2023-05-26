using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Domain.Exceptions;

public abstract class NotFoundException : ApplicationException
{
    [ExcludeFromCodeCoverage]
    protected NotFoundException(string message)
        : base("Not Found", message)
    {
    }
}
