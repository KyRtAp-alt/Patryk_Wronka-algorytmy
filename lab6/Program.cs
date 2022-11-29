namespace algorytmy_2022_gr3{

    internal class Program{

        static void Main(string[]arbs){

            Stack<int> stack = new Stack<int>();
            Console.WriteLine(stack.Count ==0);
            stack.Push(4);
            stack.Push(2);
            stack.Push(1);
            Console.WriteLine(stack.Count == 4);
            Console.WriteLine(stack.Pop() == 6);
        }
    }

    internal class Node<T>{

        public T Value { get; set; }
        public Node<T> Next{ get; set; }
    }

    public class LinkedStack<T>{

        public void Push(T item){

            if (IsEmpty()){
                head = new Node<T> {Value = item, Next = null};
            }
        }

        public T Pop(){
            throw new NotImplementedException();
        }
    }
}