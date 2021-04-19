using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            BinarySearchTree<int> root = new BinarySearchTree<int>(0);
            Assert.AreEqual(root.value, 0);
            Assert.IsFalse(root.HasLeft());
            Assert.IsFalse(root.HasRight());
            Assert.IsTrue(root.IsLeaf());
            Assert.AreEqual(root.Height(), (uint) 1);
        }

        [TestMethod]
        public void InsertTest()
        {
            BinarySearchTree<int> root = new BinarySearchTree<int>(2);
            Assert.IsFalse(root.HasLeft());
            Assert.IsFalse(root.HasRight());
            Assert.AreEqual(root.Height(), (uint) 1);

            var left = root.Insert(1);
            Assert.IsTrue(root.HasLeft());
            Assert.IsFalse(root.HasRight());
            Assert.AreEqual(left.value, 1);
            Assert.AreEqual(root.Height(), (uint) 2);

            var right = root.Insert(3);
            Assert.IsTrue(root.HasLeft());
            Assert.IsTrue(root.HasRight());
            Assert.AreEqual(right.value, 3);
            Assert.AreEqual(root.Height(), (uint) 2);

            root.Insert(0);
            Assert.IsTrue(left.HasLeft());
            Assert.IsFalse(left.HasRight());
            Assert.AreEqual(root.Height(), (uint) 3);

            root.Insert(4);
            Assert.IsFalse(right.HasLeft());
            Assert.IsTrue(right.HasRight());
            Assert.AreEqual(root.Height(), (uint) 3);
        }

        [TestMethod]
        public void EachTest()
        {
            BinarySearchTree<int> root = new BinarySearchTree<int>(3);  //        3
            root.Insert(1);                                             //       /  \
            root.Insert(0);                                             //     1      5
            root.Insert(2);                                             //   /  |    |  \
            root.Insert(5);                                             // 0    2    4    6
            root.Insert(4);                                             //
            root.Insert(6);                                             //

            int i = 0;
            int[] inOrder = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            root.EachInOrder(v => Assert.AreEqual(v, inOrder[i++]));

            i = 0;
            int[] postOrder = new int[] { 0, 2, 1, 4, 6, 5, 3 };
            root.EachPostOrder(v => Assert.AreEqual(v, postOrder[i++]));

            i = 0;
            int[] preOrder = new int[] { 3, 1, 0, 2, 5, 4, 6 };
            root.EachPreOrder(v => Assert.AreEqual(v, preOrder[i++]));
        }

        [TestMethod]
        public void FindTest()
        {
            BinarySearchTree<int> root = new BinarySearchTree<int>(3);  //        3
            root.Insert(1);                                             //       /  \
            root.Insert(0);                                             //     1      5
            root.Insert(2);                                             //   /  |    |  \
            root.Insert(5);                                             // 0    2    4    6
            root.Insert(4);                                             //
            root.Insert(6);                                             //

            Assert.IsNotNull(root.Find(3));
            Assert.IsNotNull(root.Find(1));
            Assert.IsNotNull(root.Find(5));
            Assert.IsNotNull(root.Find(0));
            Assert.IsNotNull(root.Find(6));
            Assert.IsNull(root.Find(-1));
            Assert.IsNull(root.Find(7));
        }
    }
}
