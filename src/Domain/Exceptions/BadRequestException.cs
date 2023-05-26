

using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Domain.Exceptions;
public abstract class BadRequestException : ApplicationException
{
    [ExcludeFromCodeCoverage]
    protected BadRequestException(string message)
        : base("Bad Request", message)
    {
    }
}
