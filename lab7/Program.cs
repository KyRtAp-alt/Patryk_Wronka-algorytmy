//Patryk_Wronka

namespace task_5;

public class Task5
{
    public static void Main(string[] args)
    {
        StringHexPositionSort s = new StringHexPositionSort();
        string[] arr = {"AF3", "120", "236", "11A", "23", "5", "FFFFF"};
        try
        {
            s.Sort(arr, 5);
            if (
                   arr[0] == "5"
                && arr[1] == "23"
                && arr[2] == "11A"
                && arr[3] == "120"
                && arr[4] == "236"
                && arr[5] == "AF3"
               )
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
        catch
        {
            Console.WriteLine("Test failed");
        }
    }
    //Cwiczenie 1
    //Zaimplementuj klasę do sortowania pozycyjnego liczb szesnastkowych zapisanych w łańcuchach 
    //Przykładowa tablica do posortowania
    //string[] HexNumbers = {"AF3", "12D", "236", "120", "1"};
    //tablica po sortowaniu
    //{"1", "120", "12D", "236", "AF3"}
    //Można założyć, że
    //- w tablicy są poprawne łańcuchy z liczbami szesastkowymi
    //- łańcuchy mają różną długość 
    //Możesz wzorować się na gotowym algorytmie w instrukcji nr 5

    public class StringHexPositionSort
    {
        //Zadeklaruj tablicę kolejek dla każdej cyfry szesnastkowej
        //Każda kolejka jest typu string lub char
        //Wykorzystaj klasę Queue<string> lub Queue<char>
        //Możesz zadeklarować tablicę 16 kolejek Queueu<string>[] lub słownik Dictionary<String, Queue<String>>
        //w którym kluczem jest łańcuch z jednym znakiem - cyfrą szesnastkową.
        private void Init()
        {
            //zaimplementuj zainicjowanie tablicy lub słownika kolejek
            throw new NotImplementedException();
        }

        private void Dequeue(string[] arr)
        {
            //zaimplementuje pobieranie z kolejek łańcuchów hex i umieszczanie ich w tablicy arr
            //kolejki opróżniamy zaczynając od kolejki z cyfrą 0 a kończąc na F 
            throw new NotImplementedException();
        }

        //Zaimplementuj metodę pomocniczą, aby zwracała liczbę równą cyfrze szesnastkowej na podanej pozycji (position) w łańcuchu str
        //Pozycja jest numerowana od prawej do lewej
        // np. dla łańcucha "AB12"
        // cyfra na pozycji 0 to 2,
        // cyfra na pozycji 2 to 11,
        // cyfra na pozycji 8 to 0
        //Stosowanie tej metody uprości definicję metody Enqueue
        private int ExtractDigit(string str, uint position)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        ///Zaimplementuj umieszczanie cyfr łacuchów hex z arr w kolejce odpowiadającej pozycji tej cyfry 
        /// </summary>
        /// <param name="arr">tablica sortowanych łańcuchów hex</param>
        /// <param name="position">pozycja cyfry hex wzlgędem, której sortujemy łańcuchy</param>
        private void Enqueue(string[] arr, uint position)
        {
            throw new NotImplementedException();
        }

        //Tej metody nie zmieniaj!!!
        public void Sort(string[] arr, int d)
        {
            Init();
            for (uint position = 0; position < d; position++)
            {
                Enqueue(arr, position);
                Dequeue(arr);
            }
        }
    }
}