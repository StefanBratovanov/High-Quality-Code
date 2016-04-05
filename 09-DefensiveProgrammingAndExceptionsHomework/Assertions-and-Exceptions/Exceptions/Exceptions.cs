using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 1));

            CheckPrime(23);
            CheckPrime(33);

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0)
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentNullException ane)
        {
            Console.Error.WriteLine(ane.Message);
        }
        catch (ArgumentOutOfRangeException aooe)
        {
            Console.Error.WriteLine(aooe.Message);
        }
        catch (InvalidOperationException ioe)
        {
            Console.Error.WriteLine(ioe.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }


    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("The array is empty");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("start Index", "Start index cannot be bigger then the array's length.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "The count can not be neggative.");
        }

        if (count > arr.Length)
        {
            throw new InvalidOperationException("Count cannot be bigger then the array's length");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new InvalidOperationException("Count cannot be bigger then the array's length");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("The number {0} is not prime!", number);
                return;
            }
        }
    }
}
