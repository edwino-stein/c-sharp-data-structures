using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.AreEqual(list.size, (uint) 0);
            Assert.IsTrue(list.Empty());
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.At(0), default);
        }

        [TestMethod]
        public void PushBackTest()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsTrue(list.PushBack(1));
            Assert.AreEqual(list.size, (uint) 1);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 1);

            Assert.IsTrue(list.PushBack(2));
            Assert.AreEqual(list.size, (uint) 2);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 2);

            Assert.IsTrue(list.PushBack(3));
            Assert.AreEqual(list.size, (uint) 3);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);

            for (uint i = 0; i < list.size; ++i)
            {
                Assert.AreEqual(list.At(i), (int) i+1);
            }
        }
        
        [TestMethod]
        public void PushFrontTest()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsTrue(list.PushFront(3));
            Assert.AreEqual(list.size, (uint) 1);
            Assert.AreEqual(list.First(), 3);
            Assert.AreEqual(list.Last(), 3);

            Assert.IsTrue(list.PushFront(2));
            Assert.AreEqual(list.size, (uint) 2);
            Assert.AreEqual(list.First(), 2);
            Assert.AreEqual(list.Last(), 3);

            Assert.IsTrue(list.PushFront(1));
            Assert.AreEqual(list.size, (uint) 3);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);

            for (uint i = 0; i < list.size; ++i)
            {
                Assert.AreEqual(list.At(i), (int) i + 1);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsFalse(list.Insert(4, 3));
            Assert.AreEqual(list.size, (uint) 0);
            Assert.AreEqual(list.First(), 0);
            Assert.AreEqual(list.Last(), 0);

            Assert.IsTrue(list.Insert(1, 0));
            Assert.AreEqual(list.size, (uint) 1);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 1);

            Assert.IsTrue(list.Insert(3, 1));
            Assert.AreEqual(list.size, (uint) 2);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);

            Assert.IsTrue(list.Insert(2, 1));
            Assert.AreEqual(list.size, (uint) 3);

            for (uint i = 0; i < list.size; ++i)
            {
                Assert.AreEqual(list.At(i), (int) i + 1);
            }
        }

        [TestMethod]
        public void PopFrontTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 3);

            Assert.IsTrue(list.PopFront());
            Assert.AreEqual(list.First(), 2);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 2);

            Assert.IsTrue(list.PopFront());
            Assert.AreEqual(list.First(), 3);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 1);

            Assert.IsTrue(list.PopFront());
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);

            Assert.IsFalse(list.PopFront());
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);
        }

        [TestMethod]
        public void PopBackTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 3);

            Assert.IsTrue(list.PopBack());
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 2);
            Assert.AreEqual(list.size, (uint) 2);

            Assert.IsTrue(list.PopBack());
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 1);
            Assert.AreEqual(list.size, (uint) 1);

            Assert.IsTrue(list.PopBack());
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);

            Assert.IsFalse(list.PopBack());
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);
        }

        [TestMethod]
        public void RemoveTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            Assert.IsFalse(list.Remove(3)); // invalid index

            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 3);

            Assert.IsTrue(list.Remove(1)); // remove number 2
            Assert.AreEqual(list.At(1), 3);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 3);
            Assert.AreEqual(list.size, (uint) 2);

            Assert.IsTrue(list.Remove(1)); // remove number 3
            Assert.AreEqual(list.At(1), default);
            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Last(), 1);
            Assert.AreEqual(list.size, (uint) 1);

            Assert.IsTrue(list.Remove(0));
            Assert.AreEqual(list.At(0), default);
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);

            Assert.IsFalse(list.Remove(0)); // remove number 1
            Assert.AreEqual(list.At(0), default);
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);

            
            Assert.AreEqual(list.At(0), default); // invalid index
            Assert.AreEqual(list.First(), default);
            Assert.AreEqual(list.Last(), default);
            Assert.AreEqual(list.size, (uint) 0);
        }

        [TestMethod]
        public void EachTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; ++i) list.PushBack(i);

            list.Each(
                delegate (int v, uint i)
                {
                    Assert.AreEqual(v, (int) i);
                }
            );
            
            list.Each(
                delegate (int v, uint i)
                {
                    Assert.AreEqual(v, (int) i);
                },
                true
            );

        }
    }
}
