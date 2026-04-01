using System;
using System.Net.Http;

namespace Bem.Exceptions;

public class BemIOException : BemException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public BemIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
