using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    internal class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int heapSize;

        public HeapPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            heapSize = -1;
        }

        // Insert the new item at the end of the heap and heapify up
        public void Add(T item, int priority)
        {
            if(heapSize +1 >= capacity)
            {
                throw new QueueOverflowException("Heap is full");
            }
            heapSize++;

            storage[heapSize] = new PriorityItem<T>(item, priority);
            HeapifyUp(heapSize);

        }

        public void HeapifyUp(int heapIndex)
        {
            while(heapIndex > 0)
            {
                int parentIndex = (heapIndex - 1) / 2;

                if (storage[heapIndex].Priority <= storage[parentIndex].Priority)
                {
                    return;
                }

                PriorityItem<T> temp = storage[heapIndex];
                storage[heapIndex] = storage[parentIndex];
                storage[parentIndex] = temp;

                heapIndex = parentIndex;

            }
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The heap is empty.");
            }
            return storage[0].Item;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The heap is empty.");
            }

            heapSize--;
            storage[0] = storage[heapSize];
            storage[heapSize] = null; 
            heapSize--;
            HeapifyDown(0);

        }

        public void HeapifyDown(int idx)
        {
            while (idx * 2 + 1 <= heapSize) // While the left child exists
            {
                int leftChildIdx = idx * 2 + 1;
                int rightChildIdx = idx * 2 + 2;
                int largestChildIdx = leftChildIdx;

                // Check if right child exists and has higher priority than the left child
                if (rightChildIdx <= heapSize && storage[rightChildIdx].Priority > storage[leftChildIdx].Priority)
                {
                    largestChildIdx = rightChildIdx;
                }

                // If the current node is bigger than the largest child, break the loop
                if (storage[idx].Priority >= storage[largestChildIdx].Priority)
                {
                    break;
                }

                // Swap with the largest child
                PriorityItem<T> temp = storage[idx];
                storage[idx] = storage[largestChildIdx];
                storage[largestChildIdx] = temp;

                // Move to the largest child's index
                idx = largestChildIdx;
            }
        }


        public bool IsEmpty()
        {
            return heapSize < 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i <= heapSize; i++)
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
