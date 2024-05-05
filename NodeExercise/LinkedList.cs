using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    class LinkedList<T>
    {
        public Node<T> head; // pointer to first node
        private Node<T> last; // pointer to the last node

        public LinkedList(Node<T> node)
        {
            head = node;
            last = head;
        }

        public void Append(T value)
        {
            Node<T> node = new Node<T>(value);
            last.Next = node;
            last = last.Next;   
        }

        public void Prepend(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Next = head;
            head = node;
        }

        public T Pop()
        {
            T nodeValue = last.Value;

            // run over the list till one before last
            Node<T> pointer = head;
            while(pointer.Next.Next != null)
            {
                pointer = pointer.Next;
            }

            pointer.Next = null;
            return nodeValue;

        }





    }
}
