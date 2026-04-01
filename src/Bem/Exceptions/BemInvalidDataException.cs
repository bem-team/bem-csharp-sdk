using System;

namespace Bem.Exceptions;

public class BemInvalidDataException : BemException
{
    public BemInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
