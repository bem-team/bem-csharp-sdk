using System.Net.Http;

namespace Bem.Exceptions;

public class BemForbiddenException : Bem4xxException
{
    public BemForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
