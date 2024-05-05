using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    class LinkedList<T> : IEnumerable<int>
    {
        public Node<int> head; // pointer to first node
        public Node<int> last; // pointer to the last node
        public LinkedList(Node<int> head)
        {
            this.head = head;
            last = this.head;
        }

        public void Append(int value)
        {

            Node<int> node = new Node<int>(value);
            last.Next = node;
            last = last.Next;


        }

        public void Prepend(int value)
        {
            Node<int> node = new Node<int>(value);
            node.Next = head;
            head = node;
        }

        public int Pop()
        {
            int nodeValue = last.Value;

            // run over the list till one before last
            Node<int> pointer = head;
            while (pointer.Next.Next != null)
            {
                pointer = pointer.Next;
            }

            pointer.Next = null;
            return nodeValue;

        }

        public int Unqueue()
        {
            int value = head.Value;
            head = head.Next;
            return value;
        }

        public bool IsCircular()
        {
            return last.Next != null;
        }

        Node<int> SortedMerge(Node<int> node1, Node<int> node2)
        {
            Node<int> result = null;
            // check if one of the nodes are null - return the other one
            if (node1 == null)
                return node2;
            if (node2 == null)
                return node1;

            // get the smaller node and recursively define the next node as the minimum node in the checked sequence
            if (node1.Value <= node2.Value)
            {
                result = node1;
                result.Next = SortedMerge(node1.Next, node2);
            }
            else
            {
                result = node2;
                result.Next = SortedMerge(node1, node2.Next);
            }
            return result;
        }

        public Node<int> MergeSort(Node<int> head)
        {
            // check if head is null
            if (head == null || head.Next == null)
            {
                return head;
            }

            // get the middle of the list
            Node<int> middle = GetMiddle(head);
            Node<int> nextofmiddle = middle.Next;

            // set the next of middle node to null
            middle.Next = null;

            // Apply mergeSort on left list
            Node<int> left = MergeSort(head);

            // Apply mergeSort on right list
            Node<int> right = MergeSort(nextofmiddle);

            // Merge the left and right lists
            Node<int> sortedlist = SortedMerge(left, right);
            return sortedlist;
        }

        //get the middle of the linked list
        Node<int> GetMiddle(Node<int> head)
        {
            // Base case
            if (head == null)
                return head;
            Node<int> currentPointer = head.Next;
            Node<int> previousPointer = head;

            // Move currentPointer by two and previous pointer by one
            // At the end previous pointer will point to middle node
            while (currentPointer != null)
            {
                currentPointer = currentPointer.Next;
                if (currentPointer != null)
                {
                    previousPointer = previousPointer.Next;
                    currentPointer = currentPointer.Next;
                }
            }
            return previousPointer;
        }

        private void set_last_node()
        {
            Node<int> pointer = head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }
            last = pointer;
        }
        public void Sort()
        {
            head = this.MergeSort(head);
            this.set_last_node();
        }

        public Node<int> GetMaxNode()
        {
            this.Sort();
            return last;
        }

        public Node<int> GetMinNode()
        {
            this.Sort();
            return head;
        }
        //public IEnumerable<int> ToList()
        //{
        //    return GetEnumerator();
        //}

        public IEnumerator<int> GetEnumerator()
        {
            Node<int> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        // }

        // IEnumerator IEnumerable.GetEnumerator()
        // {
        //     return this.ToList()
        // }

        //public LinkedList<int> GetEnumerator()
        //{
        //    return new LinkedList<int>();
        //}

        // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
        //private IEnumerator GetEnumerator1()
        //{
        //    yield return this.GetEnumerator();
        //}

        //IEnumerator<int> IEnumerable<int>.GetEnumerator()
        //{
        //    return (IEnumerator<int>)GetEnumerator1();
        //}
    }
}
