using System;
using System.Diagnostics;

public class Assertions
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);

            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(arr.Length > 0, "An empty array cannot be sort!");
       
        Debug.Assert(arr.Length >= 1, "An array with only one object cannot be sort!");

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) < 0, "The sorting method doesn't work correctly!");
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "The array cannot be empty!");

        Debug.Assert(startIndex < endIndex, "The start index cannot be bigger than the last one!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(minElementIndex > startIndex,"The FindMindElementIndex method doesn't return the correct value!");

        return minElementIndex;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        return -1;
    }
    
    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));

        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
    private static void Swap<T>(ref T x, ref T y) where T : IComparable<T>
    {
        Debug.Assert(x != null, "X cannot be null!");
        Debug.Assert(y != null, "Y cannot be null!");

        T oldX = x;
        x = y;
        y = oldX;
    }
}
