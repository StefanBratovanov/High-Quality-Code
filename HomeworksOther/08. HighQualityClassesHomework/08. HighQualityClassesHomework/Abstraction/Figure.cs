namespace Abstraction
{
    using System;

    public abstract class Figure
    { 
        public abstract double CalculateSurface();

        public abstract double CalculatePerimeter();

        protected static void ValidateNumber(double number, string argName)
        {
            if (number < 0)
            {
                throw new ArgumentException(string.Format($"{argName} cannot be negative!"));
            }
        }
    }
}
