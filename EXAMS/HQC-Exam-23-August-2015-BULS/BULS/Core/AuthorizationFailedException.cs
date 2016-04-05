
namespace BangaloreUniversityLearningSystem.Core
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string msg) :
             base(msg)
        {
        }
    }
}
