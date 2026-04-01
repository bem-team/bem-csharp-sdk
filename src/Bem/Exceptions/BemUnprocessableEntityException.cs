using System.Net.Http;

namespace Bem.Exceptions;

public class BemUnprocessableEntityException : Bem4xxException
{
    public BemUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
