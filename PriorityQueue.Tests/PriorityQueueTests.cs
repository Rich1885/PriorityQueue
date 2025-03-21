using System;
using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        [Test]
        public void SortedArrayPriorityQueue_ShouldWorkCorrectly()
        {
            var queue = new SortedArrayPriorityQueue<Person>(10);

            Assert.That(queue.IsEmpty(), Is.True, "Queue should be empty after initialization.");

            queue.Add(new Person("Alice"), 5);
            queue.Add(new Person("Bob"), 2);
            Assert.That(queue.Head().Name, Is.EqualTo("Alice"));

            queue.Remove();
            Assert.That(queue.Head().Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void UnsortedArrayPriorityQueue_ShouldWorkCorrectly()
        {
            var queue = new UnsortedArrayPriorityQueue<Person>(10);

            queue.Add(new Person("Alice"), 5);
            queue.Add(new Person("Bob"), 2);
            Assert.That(queue.Head().Name, Is.EqualTo("Alice"));

            queue.Remove();
            Assert.That(queue.Head().Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void SortedLinkedPriorityQueue_ShouldWorkCorrectly()
        {
            var queue = new SortedLinkedPriorityQueue<Person>();

            queue.Add(new Person("Alice"), 5);
            queue.Add(new Person("Bob"), 2);
            Assert.That(queue.Head().Name, Is.EqualTo("Alice"));

            queue.Remove();
            Assert.That(queue.Head().Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void UnsortedLinkedPriorityQueue_ShouldWorkCorrectly()
        {
            var queue = new UnsortedLinkedPriorityQueue<Person>();

            queue.Add(new Person("Alice"), 5);
            queue.Add(new Person("Bob"), 2);
            Assert.That(queue.Head().Name, Is.EqualTo("Alice"));

            queue.Remove();
            Assert.That(queue.Head().Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void HeapPriorityQueue_ShouldWorkCorrectly()
        {
            var queue = new HeapPriorityQueue<Person>(10);

            queue.Add(new Person("Alice"), 5);
            queue.Add(new Person("Bob"), 2);
            Assert.That(queue.Head().Name, Is.EqualTo("Alice"));

            queue.Remove();
            Assert.That(queue.Head().Name, Is.EqualTo("Bob"));
        }

        [Test]
        public void Queue_ShouldThrowException_WhenEmpty()
        {
            var queue = new SortedArrayPriorityQueue<Person>(10);

            Assert.Throws<QueueUnderflowException>(() => queue.Head());
            Assert.Throws<QueueUnderflowException>(() => queue.Remove());
        }

        [Test]
        public void UnsortedLinkedQueue_ShouldThrow_WhenAllRemoved()
        {
            var queue = new UnsortedLinkedPriorityQueue<Person>();

            queue.Add(new Person("Alice"), 1);
            queue.Remove();

            Assert.Throws<QueueUnderflowException>(() => queue.Head(), "Should throw exception when accessing Head() on empty queue.");
            Assert.Throws<QueueUnderflowException>(() => queue.Remove(), "Should throw exception when trying to Remove() from an empty queue.");
        }
    }
}
