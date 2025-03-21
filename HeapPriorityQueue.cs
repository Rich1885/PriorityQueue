using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class HeapPriorityQueue<T> : PriorityQueue<T>
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

        public void Add(T item, int priority)
        {
            if (heapSize + 1 >= capacity)
            {
                throw new QueueOverflowException("Heap is full");
            }
            heapSize++;

            storage[heapSize] = new PriorityItem<T>(item, priority);
            HeapifyUp(heapSize);

        }

        public void HeapifyUp(int heapIndex)
        {
            while (heapIndex > 0)
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

        public void HeapifyDown(int heapIndex)
        {
            while (heapIndex * 2 + 1 <= heapSize) 
            {
                int leftChildIdx = heapIndex * 2 + 1;
                int rightChildIdx = heapIndex * 2 + 2;
                int largestChildIdx = leftChildIdx;

                if (rightChildIdx <= heapSize && storage[rightChildIdx].Priority > storage[leftChildIdx].Priority)
                {
                    largestChildIdx = rightChildIdx;
                }

                if (storage[heapIndex].Priority >= storage[largestChildIdx].Priority)
                {
                    break;
                }

                PriorityItem<T> temp = storage[heapIndex];
                storage[heapIndex] = storage[largestChildIdx];
                storage[largestChildIdx] = temp;

                heapIndex = largestChildIdx;
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
