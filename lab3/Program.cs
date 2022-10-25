using System;

namespace lab3
{
    public class Task1
    {        
        public static bool IsInArray(int[] arr, int value)
        {
            return IsInArrayRecursive(arr, 0, arr.Length, value);
        }
        /**
         * REKURENCJA
         */
        //Zaimplementuj funkcję, która strategią dziel i zwyciężaj zwróci prawdę jeśli w tablicy
        //'arr' znajduje się wartość parametru 'value'.
        //Przykład
        //int[] arr = { 1, 2, 6 ,9 ,4, 3};
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0);          //false
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6);          //true
        //Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5);          //false
        public static bool IsInArrayRecursive(int[] arr, int start, int end, int value)
        {
            if (start > end)
            {
                return false;
            }
            else
            {
                int middle = (start + end) / 2;
                if (arr[middle] == value)
                {
                    return true;
                }
                else if (arr[middle] > value)
                {
                    return IsInArrayRecursive(arr, start, middle - 1, value);
                }
                else
                {
                    return IsInArrayRecursive(arr, middle + 1, end, value);
                }
            }
        }


        //Zdefiniuj funkcję rekurecyjną, która oblicza sumę elementów tablicy podzielnych przez 3
        //Nie można używać instrukcji iteracyjnych!!! Wartość funkcja dla pustej tablicy wynosi 0.
        //Można założyć, że tablica nie będzie równa null. Zdefiniuj funkcję pomocniczą która będzie wywoływana
        //rekurencyjnie wewnątrz SumMod3.
        public static long SumMod3(int[] arr)
        {
            return SumMod3Recursive(arr, 0, arr.Length - 1);
            
        }

        private static long SumMod3Recursive(int[] arr, int v1, int v2)
        {
            if (v1 > v2)
            {
                return 0;
            }
            else
            {
                int middle = (v1 + v2) / 2;
                if (arr[middle] % 3 == 0)
                {
                    return arr[middle] + SumMod3Recursive(arr, v1, middle - 1) + SumMod3Recursive(arr, middle + 1, v2);
                }
                else
                {
                    return SumMod3Recursive(arr, v1, middle - 1) + SumMod3Recursive(arr, middle + 1, v2);
                }
            }
        }

        //Zdefiniuj funkcję rekurencyjną, która oblicza silnię liczby.
        public static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return (n * Factorial(n - 1));
        }

        /**
         * ALGORYTMY I ZŁOŻONOŚĆ
         */
        //Zdefiniuj funkcję, która zwróci indeks liczby, która jest równa sumie pozostałych elementów tablicy
        //Przykład
        //int[] arr = {1, 3, 2, 8, 2};
        //int index = IndexOfSumOfOthers(arr);
        //funkcja w `index` powinna zwrócić 3, gdyż pod tym indeksem jest 8 równe sumie 1 + 3 + 2 + 2.
        //Jeśli w tablicy nie ma takiej liczby lub tablica jest pusta to funkcja pownna zwrócić -1.
        public static int IndexOfSumOfOthers(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == sum - arr[i])
                {
                    return i;
                }
            }
            return -1;

        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 6 ,9 ,4, 3};
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0));          
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6));          
           // Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5));
            Console.WriteLine(Factorial(5));
            Console.WriteLine(SumMod3(arr));

            int[] arr2 = {1, 3, 2, 8, 2};
            int index = IndexOfSumOfOthers(arr2);
            System.Console.WriteLine(index);
        }
    }
}