using System.Net.Http;

namespace Bem.Exceptions;

public class Bem5xxException : BemApiException
{
    public Bem5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
