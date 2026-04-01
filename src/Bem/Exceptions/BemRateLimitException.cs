using System.Net.Http;

namespace Bem.Exceptions;

public class BemRateLimitException : Bem4xxException
{
    public BemRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
