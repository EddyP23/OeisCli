using System;

namespace OeisCli.Exceptions
{
    public class InvalidInputException: Exception
    {
        public InvalidInputException(string message) : base(message) { }
        public InvalidInputException(string message, Exception innerException) : base(message, innerException) { }
    }
}
