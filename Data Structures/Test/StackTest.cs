using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTest
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Constructor()
        {
            Stack<int> stack = new Stack<int>(10);
            Assert.AreEqual(stack.Size(), (uint) 0);
            Assert.AreEqual(stack.MaxSize(), (uint) 10);
            Assert.AreEqual(stack.Top(), default);
        }

        [TestMethod]
        public void EmptyTest()
        {
            Stack<int> stack = new Stack<int>(10);
            Assert.IsTrue(stack.Empty());
            stack.Add(123);
            Assert.IsFalse(stack.Empty());
        }


        [TestMethod]
        public void FullTest()
        {
            Stack<int> stack = new Stack<int>(1);
            Assert.IsFalse(stack.Full());
            stack.Add(123);
            Assert.IsTrue(stack.Full());
        }

        [TestMethod]
        public void AddTest()
        {
            Stack<int> stack = new Stack<int>(3);

            Assert.IsTrue(stack.Add(1));
            Assert.AreEqual(stack.Top(), 1);
            Assert.IsFalse(stack.Full());

            Assert.IsTrue(stack.Add(2));
            Assert.AreEqual(stack.Top(), 2);
            Assert.IsFalse(stack.Full());

            Assert.IsTrue(stack.Add(3));
            Assert.AreEqual(stack.Top(), 3);
            Assert.IsTrue(stack.Full());

            Assert.IsFalse(stack.Add(4));
            Assert.AreEqual(stack.Top(), 3);
            Assert.IsTrue(stack.Full());
        }

        [TestMethod]
        public void PopTest()
        {
            Stack<int> stack = new Stack<int>(3);

            Assert.AreEqual(stack.Pop(), default);

            stack.Add(1);
            stack.Add(2);
            stack.Add(3);

            Assert.AreEqual(stack.Pop(), 3);
            Assert.IsFalse(stack.Empty());

            Assert.AreEqual(stack.Pop(), 2);
            Assert.IsFalse(stack.Empty());

            Assert.AreEqual(stack.Pop(), 1);
            Assert.IsTrue(stack.Empty());

            Assert.AreEqual(stack.Pop(), default);
        }
    }
}
