

namespace SimpleMathOperationsTests
{
    using System;
    using System.Diagnostics;

    class SimpleMathOperationsTests
    {
        static void Main()
        {
            int intNumber = 2;
            long longNumber = 2;
            float floatNumber = 2.0f;
            double doubleNumber = 2.0d;
            decimal decimalNumber = 2.0m;

            Console.WriteLine("*** Int: ***");

            Stopwatch intStopwatchAdd = new Stopwatch();
            intStopwatchAdd.Start();
            for (int i = 0; i < 10000000; i++)
            {
                intNumber += 1;
            }
            intStopwatchAdd.Stop();
            Console.WriteLine("Add :       {0}", intStopwatchAdd.Elapsed);

            Stopwatch intStopwatchIncrement = new Stopwatch();
            intStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                intNumber++;
            }
            intStopwatchIncrement.Stop();
            Console.WriteLine("Increment : {0}", intStopwatchIncrement.Elapsed);

            Stopwatch intStopwatchSubstract = new Stopwatch();
            intStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                intNumber -= 1;
            }
            intStopwatchSubstract.Stop();
            Console.WriteLine("Substract : {0}", intStopwatchSubstract.Elapsed);

            Stopwatch intStopwatchMultiply = new Stopwatch();
            intStopwatchMultiply.Start();
            for (int i = 0; i < 10000000; i++)
            {
                intNumber *= 1;
            }
            intStopwatchMultiply.Stop();
            Console.WriteLine("Multiply  : {0}", intStopwatchMultiply.Elapsed);

            Stopwatch intStopwatchDivide = new Stopwatch();
            intStopwatchDivide.Start();
            for (int i = 0; i < 10000000; i++)
            {
                intNumber /= 1;
            }
            intStopwatchDivide.Stop();
            Console.WriteLine("Divide    : {0}", intStopwatchDivide.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Long: ***");

            Stopwatch longStopwatchAdd = new Stopwatch();
            longStopwatchAdd.Start();
            for (int i = 0; i < 10000000; i++)
            {
                longNumber += 1;
            }
            longStopwatchAdd.Stop();
            Console.WriteLine("Add :       {0}", longStopwatchAdd.Elapsed);

            Stopwatch longStopwatchIncrement = new Stopwatch();
            longStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                longNumber++;
            }
            longStopwatchIncrement.Stop();
            Console.WriteLine("Increment : {0}", longStopwatchIncrement.Elapsed);

            Stopwatch longStopwatchSubstract = new Stopwatch();
            longStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                longNumber -= 1;
            }
            longStopwatchSubstract.Stop();
            Console.WriteLine("Substract : {0}", longStopwatchSubstract.Elapsed);

            Stopwatch longStopwatchMultiply = new Stopwatch();
            longStopwatchMultiply.Start();
            for (int i = 0; i < 10000000; i++)
            {
                longNumber *= 1;
            }
            longStopwatchMultiply.Stop();
            Console.WriteLine("Multiply  : {0}", longStopwatchMultiply.Elapsed);

            Stopwatch longStopwatchDivide = new Stopwatch();
            longStopwatchDivide.Start();
            for (int i = 0; i < 10000000; i++)
            {
                longNumber /= 1;
            }
            longStopwatchDivide.Stop();
            Console.WriteLine("Divide    : {0}", longStopwatchDivide.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Float: ***");

            Stopwatch floatStopwatchAdd = new Stopwatch();
            floatStopwatchAdd.Start();
            for (int i = 0; i < 10000000; i++)
            {
                floatNumber += 1;
            }
            floatStopwatchAdd.Stop();
            Console.WriteLine("Add :       {0}", floatStopwatchAdd.Elapsed);

            Stopwatch floatStopwatchIncrement = new Stopwatch();
            floatStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                floatNumber++;
            }
            floatStopwatchIncrement.Stop();
            Console.WriteLine("Increment : {0}", floatStopwatchIncrement.Elapsed);

            Stopwatch floatStopwatchSubstract = new Stopwatch();
            floatStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                floatNumber -= 1;
            }
            floatStopwatchSubstract.Stop();
            Console.WriteLine("Substract : {0}", floatStopwatchSubstract.Elapsed);

            Stopwatch floatStopwatchMultiply = new Stopwatch();
            floatStopwatchMultiply.Start();
            for (int i = 0; i < 10000000; i++)
            {
                floatNumber *= 1;
            }
            floatStopwatchMultiply.Stop();
            Console.WriteLine("Multiply  : {0}", floatStopwatchMultiply.Elapsed);

            Stopwatch floatStopwatchDivide = new Stopwatch();
            floatStopwatchDivide.Start();
            for (int i = 0; i < 10000000; i++)
            {
                floatNumber /= 1;
            }
            floatStopwatchDivide.Stop();
            Console.WriteLine("Divide    : {0}", floatStopwatchDivide.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Double: ***");

            Stopwatch doubleStopwatchAdd = new Stopwatch();
            doubleStopwatchAdd.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleNumber += 1;
            }
            doubleStopwatchAdd.Stop();
            Console.WriteLine("Add :       {0}", doubleStopwatchAdd.Elapsed);

            Stopwatch doubleStopwatchIncrement = new Stopwatch();
            doubleStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleNumber++;
            }
            doubleStopwatchIncrement.Stop();
            Console.WriteLine("Increment : {0}", doubleStopwatchIncrement.Elapsed);

            Stopwatch doubleStopwatchSubstract = new Stopwatch();
            doubleStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleNumber -= 1;
            }
            doubleStopwatchSubstract.Stop();
            Console.WriteLine("Substract : {0}", doubleStopwatchSubstract.Elapsed);

            Stopwatch doubleStopwatchMultiply = new Stopwatch();
            doubleStopwatchMultiply.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleNumber *= 1;
            }
            doubleStopwatchMultiply.Stop();
            Console.WriteLine("Multiply  : {0}", doubleStopwatchMultiply.Elapsed);

            Stopwatch doubleStopwatchDivide = new Stopwatch();
            doubleStopwatchDivide.Start();
            for (int i = 0; i < 10000000; i++)
            {
                doubleNumber /= 1;
            }
            doubleStopwatchDivide.Stop();
            Console.WriteLine("Divide    : {0}", doubleStopwatchDivide.Elapsed);
            Console.WriteLine();
            Console.WriteLine("*** Decimal: ***");

            Stopwatch decimalStopwatchAdd = new Stopwatch();
            decimalStopwatchAdd.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalNumber += 1;
            }
            decimalStopwatchAdd.Stop();
            Console.WriteLine("Add :       {0}", decimalStopwatchAdd.Elapsed);

            Stopwatch decimalStopwatchIncrement = new Stopwatch();
            decimalStopwatchIncrement.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalNumber++;
            }
            decimalStopwatchIncrement.Stop();
            Console.WriteLine("Increment : {0}", decimalStopwatchIncrement.Elapsed);

            Stopwatch decimalStopwatchSubstract = new Stopwatch();
            decimalStopwatchSubstract.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalNumber -= 1;
            }
            decimalStopwatchSubstract.Stop();
            Console.WriteLine("Substract : {0}", decimalStopwatchSubstract.Elapsed);

            Stopwatch decimalStopwatchMultiply = new Stopwatch();
            decimalStopwatchMultiply.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalNumber *= 1;
            }
            decimalStopwatchMultiply.Stop();
            Console.WriteLine("Multiply  : {0}", decimalStopwatchMultiply.Elapsed);

            Stopwatch decimalStopwatchDivide = new Stopwatch();
            decimalStopwatchDivide.Start();
            for (int i = 0; i < 10000000; i++)
            {
                decimalNumber /= 1;
            }
            decimalStopwatchDivide.Stop();
            Console.WriteLine("Divide    : {0}", decimalStopwatchDivide.Elapsed);
        }
    }
}
