using System;

namespace Algorytmy
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arrl = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = FindTwoDigitMin(arrl);
            if (index == 7)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            int[] arr2 = {};
            index = FindTwoDigitMin(arr2);
            if (index == -1)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            int[] arr3 = { 1, 3, 4, 123, 1234 };
            index = FindTwoDigitMin(arr3);
            if (index == -1)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        ///<summary>

        public static int FindTwoDigitMin(int[] arr)
            {
                int min = 100;
    int index = -1;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < min && arr[i] > 9)
        {
            min = arr[i];
            index = i;
        }
    }
    return index;
            }
        }
    
}