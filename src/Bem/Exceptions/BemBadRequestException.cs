using System.Net.Http;

namespace Bem.Exceptions;

public class BemBadRequestException : Bem4xxException
{
    public BemBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
