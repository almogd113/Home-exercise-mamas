using System;

namespace NodeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>(new Node<int>(1));
            linkedList.Append(2);
            linkedList.Prepend(4);
            linkedList.Append(3);
            int val = linkedList.Pop();
            Console.WriteLine(val);
        }
    }
}
