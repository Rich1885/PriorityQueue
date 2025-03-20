using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue

{
    internal class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        // Node class to represent each item in the priority queue
        private class Node
        {
            public PriorityItem<T> Data;
            public Node Next;

            public Node(PriorityItem<T> data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;

        public SortedLinkedPriorityQueue() 
        {
            head = null;
        }


        // Adds a new item to the priority queue by priority
        public void Add(T item, int priority)
        {
            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);
            Node newNode = new Node(newItem);

            // If the list is empty or the new item has the highest priority insert at the head
            if (head == null || head.Data.Priority < newNode.Data.Priority)
            {
                newNode.Next = head;
                head = newNode;
            } else
            {
                // Traverse the list to find the correct position to insert based on prioirty
                Node temp = head;
                while(temp.Next != null &&  temp.Next.Data.Priority > priority)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
            }
        }

        // Returns the highest priority item
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to check");
            }
            return head.Data.Item;
        }

        // Removes the highest priority item
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to remove");
            }
            head = head.Next;

        }

        // Checks if the queue is empty
        public bool IsEmpty()
        {
            return head == null;
        }

        // Returns a string of the queue
        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";

            Node temp = head;

            while (temp != null)
            {
                result += temp.Data.ToString();
                temp = temp.Next;
            }

            result += "]";
            return result;
        }
    }

    
}
