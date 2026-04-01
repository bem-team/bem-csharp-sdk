using System.Net.Http;

namespace Bem.Exceptions;

public class Bem4xxException : BemApiException
{
    public Bem4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
