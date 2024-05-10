using System;
using System.Collections.Generic;

namespace NodeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList<int> linkedList = new LinkedList<int>(new Node<int>(1));
            //linkedList.Append(2);
            //linkedList.Prepend(4);
            //linkedList.Append(3);
            //int val = linkedList.Pop();
            ////Console.WriteLine(val);
            //int val2 = linkedList.Unqueue();
            //linkedList.Prepend(-1);
            //linkedList.Append(23);
            ////Console.WriteLine(val2);
            //Console.WriteLine(linkedList.Head.Value);
            ////linkedList.last.Next = linkedList.head;
            ////Console.WriteLine(linkedList.IsCircular());

            ////linkedList.ToList();
            ////Node<int> new_head = linkedList.MergeSort(linkedList.head);

            //Node<int> max = linkedList.GetMaxNode();
            //Node<int> min = linkedList.GetMinNode();
            //IEnumerable<int> a = linkedList.ToList();


            NumericalExpression numericalExpression = new NumericalExpression(2);
            Console.WriteLine("numerical expression: " + numericalExpression.GetValue());
           // Console.WriteLine(NumericalExpression.SumLetters(1));


        }
    }
}
