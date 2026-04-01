using System.Net.Http;

namespace Bem.Exceptions;

public class BemUnauthorizedException : Bem4xxException
{
    public BemUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
