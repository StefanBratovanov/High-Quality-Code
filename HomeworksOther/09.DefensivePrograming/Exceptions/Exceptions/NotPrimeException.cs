using System;

namespace Exceptions_Homework.Exceptions
{
    public class NotPrimeException : Exception
    {
        public NotPrimeException(string message)
            : base(message)
        {
        }
    }
}
