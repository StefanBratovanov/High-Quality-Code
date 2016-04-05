using System;

namespace Exceptions_Homework.Exceptions
{
    public class NullExamsException : Exception
    {
        public NullExamsException(string message)
            : base(message)
        {
        }
    }
}
