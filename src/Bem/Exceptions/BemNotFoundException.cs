using System.Net.Http;

namespace Bem.Exceptions;

public class BemNotFoundException : Bem4xxException
{
    public BemNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
