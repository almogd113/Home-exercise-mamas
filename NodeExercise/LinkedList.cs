using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    class LinkedList<T>
    {
        public Node<T> head;
        private Node<T> last;

        public LinkedList()
        {
            last = head;
        }

        public void Append(Node<T> node)
        {
            last.Next = node;
            last = node;
        }





    }
}
