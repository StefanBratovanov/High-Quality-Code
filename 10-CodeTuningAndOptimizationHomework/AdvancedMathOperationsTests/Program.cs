
namespace AdvancedMathOperationsTests
{
    using System;
    using System.Diagnostics;

    class AdvancedMathOperationsTests
    {
        static void Main()
        {
            
            float floatNumber = 2.0f;
            double doubleNumber = 2.0d;
            decimal decimalNumber = 2.0m;
            double doubleResult = 0.0d;
            decimal decimalResult = 0.0m;

            Console.WriteLine("*** Float: ***");

            Stopwatch floatStopwatchSqrt = new Stopwatch();
            floatStopwatchSqrt.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sqrt(floatNumber);
            }
            floatStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt :      {0}", floatStopwatchSqrt.Elapsed);

            Stopwatch floatStopwatchIncrement = new Stopwatch();
            floatStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Log(floatNumber);
            }
            floatStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm : {0}", floatStopwatchIncrement.Elapsed);

            Stopwatch floatStopwatchSubstract = new Stopwatch();
            floatStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sin(floatNumber);
            }
            floatStopwatchSubstract.Stop();
            Console.WriteLine("Sinus :     {0}", floatStopwatchSubstract.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Double: ***");

            Stopwatch doubleStopwatchSqrt = new Stopwatch();
            doubleStopwatchSqrt.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sqrt(doubleNumber);
            }
            doubleStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt :      {0}", doubleStopwatchSqrt.Elapsed);

            Stopwatch doubleStopwatchIncrement = new Stopwatch();
            doubleStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Log(doubleNumber);
            }
            doubleStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm : {0}", doubleStopwatchIncrement.Elapsed);

            Stopwatch doubleStopwatchSubstract = new Stopwatch();
            doubleStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sin(doubleNumber);
            }
            doubleStopwatchSubstract.Stop();
            Console.WriteLine("Sinus :     {0}", doubleStopwatchSubstract.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Decimal: ***");

            Stopwatch decimalStopwatchSqrt = new Stopwatch();
            decimalStopwatchSqrt.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Sqrt((double)decimalNumber);
            }
            decimalStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt :      {0}", decimalStopwatchSqrt.Elapsed);

            Stopwatch decimalStopwatchIncrement = new Stopwatch();
            decimalStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Log((double)decimalNumber);
            }
            decimalStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm : {0}", decimalStopwatchIncrement.Elapsed);

            Stopwatch decimalStopwatchSubstract = new Stopwatch();
            decimalStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Sin((double)decimalNumber);
            }
            decimalStopwatchSubstract.Stop();
            Console.WriteLine("Sinus :     {0}", decimalStopwatchSubstract.Elapsed);
        }
    }
}
