using System;
using System.Net.Http;

namespace Bem.Exceptions;

public class BemException : Exception
{
    public BemException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected BemException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
