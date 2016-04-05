﻿namespace AirConditionerTestingSystem.Exceptions
{
    using System;

    public class DuplicateEntryException : DivideByZeroException
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
