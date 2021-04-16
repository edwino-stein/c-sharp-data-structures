using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;


namespace DataStructuresTest
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void Contructor()
        {
            Queue<int> queue = new Queue<int>(10);

            Assert.AreEqual(queue.maxSize, (uint) 10);
            Assert.AreEqual(queue.size, (uint) 0);

            Assert.IsTrue(queue.Empty());
            Assert.IsFalse(queue.Full());

            Assert.AreEqual(queue.frontPointer, (uint) 0);
            Assert.AreEqual(queue.Front(), default);

            Assert.AreEqual(queue.backPointer, (uint) 9);
            Assert.AreEqual(queue.Back(), default);
        }

        [TestMethod]
        public void PushTest()
        {
            Queue<int> queue = new Queue<int>(3);

            Assert.AreEqual(queue.backPointer, (uint) 2);

            Assert.IsTrue(queue.Push(1));
            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Back(), 1);
            Assert.IsFalse(queue.Full());
            Assert.AreEqual(queue.backPointer, (uint) 0);

            Assert.IsTrue(queue.Push(2));
            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Back(), 2);
            Assert.IsFalse(queue.Full());
            Assert.AreEqual(queue.backPointer, (uint) 1);

            Assert.IsTrue(queue.Push(3));
            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Back(), 3);
            Assert.IsTrue(queue.Full());
            Assert.AreEqual(queue.backPointer, (uint) 2);

            Assert.IsFalse(queue.Push(4));
            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Back(), 3);
            Assert.IsTrue(queue.Full());
            Assert.AreEqual(queue.backPointer, (uint) 2);
        }

        [TestMethod]
        public void PopTest()
        {
            Queue<int> queue = new Queue<int>(3);

            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Back(), 3);
            Assert.AreEqual(queue.frontPointer, (uint) 0);
            Assert.IsFalse(queue.Empty());

            Assert.IsTrue(queue.Pop());
            Assert.AreEqual(queue.Front(), 2);
            Assert.AreEqual(queue.Back(), 3);
            Assert.AreEqual(queue.frontPointer, (uint) 1);
            Assert.IsFalse(queue.Empty());

            Assert.IsTrue(queue.Pop());
            Assert.AreEqual(queue.Front(), 3);
            Assert.AreEqual(queue.Back(), 3);
            Assert.AreEqual(queue.frontPointer, (uint) 2);
            Assert.IsFalse(queue.Empty());

            Assert.IsTrue(queue.Pop());
            Assert.AreEqual(queue.Front(), default);
            Assert.AreEqual(queue.Back(), default);
            Assert.AreEqual(queue.frontPointer, (uint) 0);
            Assert.IsTrue(queue.Empty());

            Assert.IsFalse(queue.Pop());
            Assert.AreEqual(queue.Front(), default);
            Assert.AreEqual(queue.Back(), default);
            Assert.AreEqual(queue.frontPointer, (uint) 0);
            Assert.IsTrue(queue.Empty());
        }

    }
}
