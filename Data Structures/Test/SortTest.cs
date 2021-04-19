using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTest
{   
    [TestClass]
    public class SortTest
    {
        private int[] data0 = new int[] { 1, 2, 3, 4, 5 };
        private int[] data1 = new int[] { 5, 4, 3, 2, 1 };
        private int[] data2 = new int[] { 3, 2, 5, 1, 4 };

        [TestMethod]
        public void DefaultCompareHandleTest()
        {
            Assert.IsFalse(Sort<int>.DefaultCompareHandle(1, 2));
            Assert.IsTrue(Sort<int>.DefaultCompareHandle(2, 1));
            Assert.IsTrue(Sort<int>.DefaultCompareHandle(0, 0));
            
            Assert.IsFalse(Sort<string>.DefaultCompareHandle("abc", "cba"));
            Assert.IsTrue(Sort<string>.DefaultCompareHandle("cba", "abc"));
            Assert.IsTrue(Sort<string>.DefaultCompareHandle("abc", "abc"));
            Assert.IsTrue(Sort<string>.DefaultCompareHandle("ABC", "abc"));
            Assert.IsFalse(Sort<string>.DefaultCompareHandle("abc", "ABC"));
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            int[] data = (int[]) this.data1.Clone();
            Sort<int>.SelectionSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data2.Clone();
            Sort<int>.SelectionSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data0.Clone();
            Sort<int>.SelectionSort(data, (int v1, int v2) => v1 >= v2);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            int[] data = (int[])this.data1.Clone();
            Sort<int>.InsertionSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data2.Clone();
            Sort<int>.InsertionSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data0.Clone();
            Sort<int>.InsertionSort(data, (int v1, int v2) => v1 >= v2);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            int[] data = (int[])this.data1.Clone();
            Sort<int>.BubbleSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data2.Clone();
            Sort<int>.BubbleSort(data);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);

            data = (int[])this.data0.Clone();
            Sort<int>.BubbleSort(data, (int v1, int v2) => v1 >= v2);
            for (int i = 0; i < data.Length; ++i) Assert.AreEqual(data[i], data0[i]);
        }
    }
}
