﻿using System;
using System.Collections.Generic;

namespace OOP_Exercise
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
            //linkedList.Last.Next = linkedList.Head;
            //Console.WriteLine(linkedList.IsCircular());

            //linkedList.ToList();
            //Node<int> new_head = linkedList.MergeSort(linkedList.Head);

            //Node<int> max = linkedList.GetMaxNode();
            //Node<int> min = linkedList.GetMinNode();
            //IEnumerable<int> a = linkedList.ToList();

            NumericalExpression numericalExpression = new NumericalExpression(999999999999);
            Console.WriteLine("numerical expression: " + numericalExpression.ToString());
            Console.WriteLine(NumericalExpression.SumLetters(numericalExpression));
        }
    }
}
