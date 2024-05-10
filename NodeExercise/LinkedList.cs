using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    public class LinkedList<T>
    {
        public Node<int> Head { get; private set; } // pointer to first node
        public Node<int> Last { get; private set; } // pointer to the last node
        private Node<int> _min;
        private Node<int> _max;
        public LinkedList(Node<int> head)
        {
            this.Head = head;
            Last = this.Head;
            _min = head;
            _max = head;
        }

        public void Append(int value)
        {

            Node<int> node = new Node<int>(value);
            Last.Next = node;
            Last = Last.Next;
            this.SetMinNodeWhenAdding(node);
            this.SetMaxNodeWhenAdding(node);


        }

        public void Prepend(int value)
        {
            Node<int> node = new Node<int>(value);
            node.Next = Head;
            Head = node;
            this.SetMinNodeWhenAdding(node);
            this.SetMaxNodeWhenAdding(node);
        }

        public int Pop()
        {
            int nodeValue = Last.Value;

            // run over the list till one before last
            Node<int> pointer = Head;
            while (pointer.Next.Next != null)
            {
                pointer = pointer.Next;
            }
            // set min if neccesary: 
            SetMinWhenRemoving(pointer.Next);
            // set max if neccesary: 
            SetMaxWhenRemoving(pointer.Next);
            pointer.Next = null;
            Last = pointer;


            return nodeValue;

        }

        public int Unqueue()
        {
            Node<int> originalHead = Head;
            this.Head = originalHead.Next;
            // set min if neccesary: 
            SetMinWhenRemoving(originalHead);
            // set max if neccesary: 
            SetMaxWhenRemoving(originalHead);

            return originalHead.Value;
        }

        public bool IsCircular()
        {
            return Last.Next != null;
        }

        private void SetMinNodeWhenAdding(Node<int> node)
        {
            if (node.Value < _min.Value)
                _min = node;
        }

        private void SetMaxNodeWhenAdding(Node<int> node)
        {
            if (node.Value > _max.Value)
                _max = node;
        }

        private void SetMinWhenRemoving(Node<int> node)
        {
            if (_min != node)
                return;
            Node<int> pointer = Head;
            _min = Head;
            while (pointer != null)
            {
                if (pointer.Value < _min.Value)
                    _min = pointer; // set min node
                pointer = pointer.Next;
            }
        }

        private void SetMaxWhenRemoving(Node<int> node)
        {
            if (_max != node)
                return;
            Node<int> pointer = Head;
            _max = Head;
            while (pointer != null)
            {
                if (pointer.Value > _max.Value)
                    _max = pointer; // set min node
                pointer = pointer.Next;
            }
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

        private void SetLastNode()
        {
            Node<int> pointer = Head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }
            Last = pointer;
        }

        public void Sort()
        {
            Head = this.MergeSort(Head);
            this.SetLastNode();
        }

        public Node<int> GetMaxNode()
        {
            return _max;
        }

        public Node<int> GetMinNode()
        {
            return _min;
        }
        public IEnumerable<int> ToList()
        {

            Node<int> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

       

    }
}
