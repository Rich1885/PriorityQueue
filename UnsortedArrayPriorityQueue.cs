using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    internal class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        // Check if array is empty 
        public bool IsEmpty()
        {
            return tailIndex < 0;
        }

        // Find the highest priority item and return it 
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            int highestPriorityIndex = FindHighestPriorityItem();
            return storage[highestPriorityIndex].Item;
        }

        // Add an item to the end of the array 
        public void Add(T item, int priority)
        {

            tailIndex++;
            if (tailIndex >= capacity)
            {
                throw new QueueOverflowException();
            }
            storage[tailIndex] = new PriorityItem<T>(item, priority);


        }


        // Removing the highest priority item from the arrayy
        public void Remove()
        {
            if(IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            // Find and replace the highest priority item with the last item
            int removedIndex = FindHighestPriorityItem();
            storage[removedIndex] = storage[tailIndex];
            storage[tailIndex] = null;
            tailIndex--;

        }

        // Iterate through the array to find the highest priority item
        public int FindHighestPriorityItem()
        {
            int highestPriority = 0;

            for(int i = 0; i <= tailIndex; i++)
            {
                if (storage[i] != null && storage[i].Priority > storage[highestPriority].Priority)
                {
                    highestPriority = i;
                }
            }
            return highestPriority;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
