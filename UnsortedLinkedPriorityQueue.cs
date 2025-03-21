using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PriorityQueue
{
    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>   
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

        public UnsortedLinkedPriorityQueue()
        {
            head = null;
        }

        // Add an item to the queue
        public void Add(T item, int priority)
        {
            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);
            Node newNode = new Node(newItem);

                newNode.Next = head;
                head = newNode;
        }

        // Find the highest priority item and return it 
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to check");
            }

            Node highestPriorityNode = FindHighestPriorityItem();
            return highestPriorityNode.Data.Item;
        }

        // Removing the highest priority item from the queue
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to remove");
            }

            Node highestPriorityNode = FindHighestPriorityItem();

            // If the head is the highest priority remove it
            if (head == highestPriorityNode)
            {
                head = head.Next;
                return;
            }

            // Traverse the list to find the node to remove
            Node temp = head;
            Node previous = null;

            while(temp != null && temp != highestPriorityNode)
            {
                previous = temp;
                temp = temp.Next;
            }
            // If the node was found and it's not the head
            if (previous != null)
            {
                previous.Next = temp.Next;
            }

        }

        // Check if queue is empty
        public bool IsEmpty()
        {
            return head == null;
        }

        // Go through the queue and find the highest priority item
        private Node FindHighestPriorityItem()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            Node highestPriorityNode = head;
            Node temp = head;
            while (temp != null)
            {
                if(temp.Data.Priority > highestPriorityNode.Data.Priority)
                {
                    highestPriorityNode = temp;
                }
                temp = temp.Next;
            }
            return highestPriorityNode;
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
