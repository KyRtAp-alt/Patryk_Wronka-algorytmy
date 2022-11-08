using System;

namespace App
{
    public class Task2
    {
        /// <summary>
        /// W tablicy gold znajdują się dodatnie liczby reprezetujące złoto. 
        /// Górnik zbiera złoto z komórek, zaczyna od dowolnej komórki górnego wiersza (n) i 
        /// i porusza się w dół do dolnego wiersza (0). Może przejść tylko do komórki po prawej lub
        /// do komórki na przekątnej: w prawo w górę lub w prawo w dół, ale ostatecznie musi znaleźć się w dolnym wierszu (0).
        /// Zaimplementuj algorytm, który wyznaczy największa liczbę złota zebraną przez górnika.
        /// </summary>
        /// <param name="gold">Dwuwymiarowa tablica liczb dodatnich</param>
        /// <returns>Liczba zebranego złota</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <summary>
        // Przykłady
        // Wejście: gold[][] = {{1, 3, 3},
        //     {2, 1, 4},
        //     {0, 6, 4}};
        // Wyjście: 12
        // {(1,0)->(2,1)->(1,2)}
        //
        // Wejście: gold[][] = { {1, 3, 1, 5},
        //     {2, 2, 4, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 1, 2}};
        // Wyjście: 16
        //     (2,0) -> (1,1) -> (1,2) -> (0,3) LUB
        //     (2,0) -> (3,1) -> (2,2) -> (2,3)
        //
        // Wejście : gold[][] = {{10, 33, 13, 15},
        //     {22, 21, 04, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 14, 2}};
        // Wyjście: 83 
        // Uwaga!!!
        // Najłatwiej zrealizować algorytm w postaci rekurencyjnej.
        // Memoizacja zmniejszy złożoność czasową.
        static public int CollectGold(int[,] gold)
        {
            int width = gold.GetLength(0);
            int height = gold.GetLength(1);
            int[,] memo = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    memo[i, j] = -1;
                }
            }

            int max = 0;
            for (int i = 0; i < width; i++)
            {
                max = Math.Max(max, CollectGoldHelper(gold, i, height - 1, memo));
            }

            return max;
        }
        static public int CollectGoldHelper(int[,] gold, int row, int col, int[,] memo)
        {
            if (col == 0)
            {
                return gold[row, col];
            }

            if (memo[row, col] != -1)
            {
                return memo[row, col];
            }

            int max = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i >= 0 && i < gold.GetLength(0))
                {
                    max = Math.Max(max, CollectGoldHelper(gold, i, col - 1, memo));
                }
            }

            memo[row, col] = max + gold[row, col];
            return memo[row, col];
        }

static public int MinProduct(int[] arr)
        {
            int neg_min = int.MinValue;
            int pos_min = int.MinValue;
            int negsum = 0, countZero = 0;
            int product = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    countZero++;
                    continue;
                }
                if (arr[i] < 0)
                {
                    neg_min++;
                    neg_min = Math.Max(pos_min, arr[i]);
                }
                if (arr[i] > 0 && arr[i] < pos_min)
                {
                    pos_min = arr[i];
                }
                {
                    pos_min = arr[i];
                }
                product *= arr[i];

            }
            if (neg_min == arr.Length || (negsum== 0 && countZero > 0))
                return 0;

            if (neg_min == 0)
                return pos_min;
                
            if (neg_min == 0)
                return pos_min;

            if(neg_min % 2 == 0 && neg_min != 0)
            {
                product = product / neg_min;
            }
            return product;
        }

        static void Main(string[] args)
        {
            int[,] gold = new int[,] { { 1, 3, 1, 5 }, { 2, 2, 4, 1 }, { 5, 0, 2, 3 }, { 0, 6, 1, 2 } };
            Console.WriteLine(CollectGold(gold));
            int[] arr = new int[] { 0, 2, 4, 6 };
            Console.WriteLine(MinProduct(arr));
        }
    }
}