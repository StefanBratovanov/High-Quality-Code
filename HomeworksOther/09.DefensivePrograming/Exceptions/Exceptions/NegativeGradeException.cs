using System;
namespace Exceptions_Homework.Exceptions
{
    public class NegativeGradeException : Exception
    {
        public NegativeGradeException(string message)
            : base(message)
        {
        }
    }
}
