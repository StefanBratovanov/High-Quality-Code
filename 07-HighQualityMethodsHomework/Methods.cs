namespace Methods
{
    using System;

    class Methods
    {
        static void Main()
        {
            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 03.17.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 11.03.1993");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(CalcDistanceBetweenTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal line? " + IsHorizontalLine(3, 3));
            Console.WriteLine("Vertical line? " + IsVerticalLine(-1, 2.5));

            Console.WriteLine(NumberToDigit(5));
            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");
        }

        static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("number of elements", "Insert at least one element");
            }

            var maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            return maxElement;
        }

        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides must be positive");
            }

            var halfPerimeter = (a + b + c) / 2;
            var area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        static double CalcDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            var deltaX = x1 - x2;
            var deltaY = y1 - y2;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }

        static bool IsHorizontalLine(double y1, double y2)
        {
            bool isHorizontalLine = y1 == y2;

            return isHorizontalLine;
        }

        static bool IsVerticalLine(double x1, double x2)
        {
            bool isVerticalLine = x1 == x2;

            return isVerticalLine;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("number", "Number must be in range [0-9]");
            }
        }

        static void PrintNumberInFormat(double number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Incorrect number format");
            }
        }
    }
}
