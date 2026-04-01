using System.Net.Http;

namespace Bem.Exceptions;

public class BemUnexpectedStatusCodeException : BemApiException
{
    public BemUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
