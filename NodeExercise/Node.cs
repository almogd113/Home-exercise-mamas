using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    public class Node<T>
    {
        public int Value{ get; set; }
        public Node<int> Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public Node(int value, Node<int> next)
        {
            Value = value;
            Next = next;
        }

    }
}
