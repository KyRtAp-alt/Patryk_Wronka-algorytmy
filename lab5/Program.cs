using System;
using System.Collections;
using System.Runtime.Intrinsics.Arm;

namespace App
{
    public class Student
    {
        
        public int Id { get; set; }
        public string? SureName { get; set; }
        public string? Name { get; set; }
        public DateTime Birth { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {SureName}, {Birth}";
        }
    }
    /// <summary>
    /// Przykład klasy komparatora, porównującego pola Id klasy Student
    /// </summary>
    public class StudentIdComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Id.CompareTo(y?.Id);       //stawiając znak minus przed  wyrażeniem można zmienić porządek z rosnącego na malejący
        }
    }
    public class StudentBirthComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birth.CompareTo(y?.Birth);
        }
    }

    public class Task3Examples
    {
        /// <summary>
        /// Przykład sortowania z użyciem klasy Array i własnego komparatora
        /// </summary>
        /// <param name="students"></param>
        public static void SortById(Student[] students)
        {
            Array.Sort(students, new StudentIdComparer());
        } 
        /// <summary>
        /// Przykład działania metody BinarySearch klasy Array i zdefiniowanego wyżej komparatora
        /// </summary>
        /// <param name="students">posortowana tablica studentów</param>
        /// <param name="id">id szukanego studenta</param>
        /// <returns></returns>
        public static Student? FindStudentById(Student[] students, int id)
        {
            //W przykładzie szukany obiekt studenta składa się wyłącznie z Id (pozostałe pola są null),
            //bo przekazany komparator uwzględnia  wyłącznie to pole w klasie Student.
            //
            int index = Array.BinarySearch(students, new Student() {Id = id}, new StudentIdComparer());
            return index >= 0 ? students[index] : null;
        }
        
    }

    public class Task3
    {
        /// <summary>
        /// Zdefiniuj funkcję sortującą metodą bąbelkową wg pola SureName, dla identycznych nazwisk wg Name. Dla obu pól sorotwanie w porządku malejącym (od Z do A).
        /// Wskazówka
        /// Wykorzystaj metodę CompareTo klasy string np. a.CompareTo(b);
        /// Zwraca ona wartości:
        /// dodatnia liczba- gdy łańcuch a jest większy od b
        /// ujemna liczba - gdy łańcuch a jest mniejszy od b
        /// 0 - gdy łańcuchy a i b są identyczne
        /// </summary>
        /// <param name="students">Sortowana tablica obiektów klasy Student</param>
        public static void SortBySureName(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students.Length - 1; j++)
                {
                    if (students[j].SureName.CompareTo(students[j + 1].SureName) < 0)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                    else if (students[j].SureName.CompareTo(students[j + 1].SureName) == 0)
                    {
                        if (students[j].Name.CompareTo(students[j + 1].Name) < 0)
                        {
                            Student temp = students[j];
                            students[j] = students[j + 1];
                            students[j + 1] = temp;
                        }
                    }
                    
                }
            }
        }
        public static void BubbleSortByNameAndSureName(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students.Length - 1; j++)
                {
                    if (students[j].Name.CompareTo(students[j + 1].Name) < 0)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                    else if (students[j].Name.CompareTo(students[j + 1].Name) == 0)
                    {
                        if (students[j].SureName.CompareTo(students[j + 1].SureName) < 0)
                        {
                            Student temp = students[j];
                            students[j] = students[j + 1];
                            students[j + 1] = temp;
                        }
                    }
                    
                }
            }
        }

        
        /// <summary>
        /// Korzystając z klasy Array i metody Sort posortuj tablicę studentów wg ich dat urodzin w porządku od najstarszego  do najmłodszego studenta.
        /// Dla studentów urodzonych w tym samym dniu, decyduje nazwisko w porządku rosnącym.
        /// </summary>
        /// <param name="students">Sortowana tablica obiektów klasy student</param>
        public static void SortByBirth(Student[] students)
        {
            Array.Sort(students, (x, y) =>
            {
                if (x.Birth.CompareTo(y.Birth) == 0)
                {
                    return x.SureName.CompareTo(y.SureName);
                }
                return x.Birth.CompareTo(y.Birth);
            });
        }

        /// <summary>
        /// Korzystając z klasy Array i metody BinarySearch wyszukaj wszystkich studentów o podanej dacie urodzin
        /// w posortowanej rosnąco wg urodzin tablicy obiektów klasy Student.
        /// W tym zadaniu liczy sie czas wyszukiwania, więc nie należy stosować wyszukiwania liniowego, które
        /// ma złożoność O(n), gdy wyszukiwanie binarne ma O(log2(n)). Testy będą operować dużymi tablicami!
        /// Wskazówki:
        /// 1. Zdefiniuj klasę interfejsu IComparer, która porównuje tylko daty urodzin pobrane z pola Birth klasy Student
        ///    Zignoruj czas w polu Birth,  
        /// 2. Metoda BinarySearch zwraca indeks pierwszego znalezionego obiektu! Należy od tego indeksu przeszukać sąsiednie
        ///    komórki, czy mają tę samą datę urodzin i je uwzględnić w wyniku. Zwrócona wartość -1 oznacza brak szukanych elementów. 
        /// 3. Możesz znaleźć zakres indeksów komórek, w których są studenci o tych samych datach urodzin.
        ///    Tablicę wynikową możesz uzyskać wykonująć na Array metodę Copy np.
        ///    Array.Copy(students, startIndex, result, 0, result.Length);
        ///    gdzie:
        ///        startIndex - indeks pierwszego student o szukanej dacie urodzin
        ///        result - tablica wynikowa studentów, której rozmiar wyznacza zakres indeksów od startIndex do endIndex (ostatni student o szukanej dacie)
        /// </summary>
        /// <param name="student">posortowana rosnąco tablica studentów wg dat urodzin.</param>
        /// <param name="birth">data urodzin wyszukiwanych studentów</param>
        /// <returns>tablica wyszukanych studentów</returns>
       public static Student[] FindByBirth(Student[] students, DateTime birth)
        {
            int index = Array.BinarySearch(students, new Student() {Birth = birth}, new StudentBirthComparer());
            if (index < 0)
            {
                return new Student[0];
            }
            int startIndex = index;
            int endIndex = index;
            while (startIndex > 0 && students[startIndex - 1].Birth == birth)
            {
                startIndex--;
            }
            while (endIndex < students.Length - 1 && students[endIndex + 1].Birth == birth)
            {
                endIndex++;
            }
            Student[] result = new Student[endIndex - startIndex + 1];
            Array.Copy(students, startIndex, result, 0, result.Length);
            return result;
        }
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student() {Name = "Jan", SureName = "Kowalski", Birth = new DateTime(2000, 1, 1)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 1)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 2)},
                new Student() {Name = "Jan", SureName = "Zowak", Birth = new DateTime(2000, 1, 3)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 3)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 4)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 5)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 6)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 7)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 8)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 9)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 10)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 11)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 12)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 13)},
                new Student() {Name = "Jan", SureName = "Nowak", Birth = new DateTime(2000, 1, 14)},
                
            };
            BubbleSortByNameAndSureName(students);
            System.Console.WriteLine( string.Join("", students.Select(s => s.ToString() + "")));
        }
    
    }
}
    

        
        