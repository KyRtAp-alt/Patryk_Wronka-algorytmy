public class App
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Repeat("#", 5));
        Console.WriteLine(RepeatRecursive("#", 5));
        //RepeatRecursive("#", 4);
        //RepeatRecursive("#",3);
        //RepeatRecursive("#",2);
        //RepeatRecursive("#",1);
        //RepeatRecursive("#",0);
        //RepeatRecursive("#",-1);
        Console.WriteLine(string.Join(" ", Change(13)));
        Console.WriteLine(Fib(44));
        Console.WriteLine(QuickFib(46));
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine(string.Join(" ", arr));
    }

    public static string Repeat(string s, int n)
    {
        string result = "";
        for (int i = 0; i < n; i++)
        {
            result += s; // result = result(s, i - 1) + s;
        }
        return result;
    }

//Regeryncyjne sumowanie elementow w tablicy




    public static string RepeatRecursive(string s, int n)
   
        {
            if (n <= 0)
            {
                return "";
            }
            else
            {
                return RepeatRecursive(s, n - 1) + s;
            }
            
        }

    //Wydawanie reszty dla trzech nominałow 1,2 i 5
    //Zdefinowac dla dowolnych nominałow w tablicy np {1,2,5,10,20,50,100}



    public static int[] Change(int amount)
    {
        int[] arr = new int[3];
        arr[2] = amount / 5;
        amount = amount - arr[2] * 5;
        arr[1] = amount / 2;
        amount = amount - arr[1] * 2;
        arr[0] = amount;
        amount = amount - arr[0] * 1;
        return arr;

    }


    public static long Fib(int n)
    {
        if (n < 2)
        {
            return n;
        }
        else
        {
            return Fib(n - 1) + Fib(n - 2);
        }
    }

    public static long FibMem(int n, long[] mem )
    {
        if (n < 2)
        {
            return n;
        }
            if (mem[n - 1] == 0)
            {
                mem[n - 1] = FibMem(n - 1, mem);
            }

            if (mem[n - 2] == 0)
            {
                mem[n - 2] = FibMem(n - 2, mem);
            }
            return mem[n - 2 ] + mem[n - 1];
        
    }

    public static long QuickFib(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("n must be non-negative");
        }
        return FibMem(n, new long[n]);
    }

    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = arr.Length -1; j > i; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
          
        }
    }

    public static int ArraySum(int[] arr, int start, int end)
    {
        if (start == end)
        {
            return arr[start];
        }
        else
        {
            int mid = (start + end) / 2;
            return ArraySum(arr, start, mid) + ArraySum(arr, mid + 1, end);
        }
    }
    
 
}