using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree <T>
    {
        public delegate bool CompareHandle(T v1, T v2);
        public delegate void EachHandle(T value);

        public T value { get; private set; }
        private BinarySearchTree<T>? left;
        private BinarySearchTree<T>? right;
        private CompareHandle compareHandle;

        public BinarySearchTree(T value, CompareHandle compareHandle)
        {
            this.value = value;
            this.compareHandle = compareHandle;
            this.left = null;
            this.right = null;
        }
        
        public BinarySearchTree(T value)
        {
            this.value = value;
            this.compareHandle = DefaultCompareHandle;
            this.left = null;
            this.right = null;
        }

        public BinarySearchTree<T> Insert(T value)
        {
            if(this.compareHandle(value, this.value))
            {
                if (this.HasRight()) return this.right.Insert(value);
                this.right = new BinarySearchTree<T>(value, this.compareHandle);
                return this.right;
            }
            else
            {
                if (this.HasLeft()) return this.left.Insert(value);
                this.left = new BinarySearchTree<T>(value, this.compareHandle);
                return this.left;
            }
        }

        public BinarySearchTree<T>? Find(T value)
        {
            if (Comparer<T>.Default.Compare(this.value, value) == 0) return this;
            if (this.compareHandle(value, this.value))
            {
                return this.HasRight() ? this.right.Find(value) : null;
            }
            else
            {
                return this.HasLeft() ? this.left.Find(value) : null;
            }
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public void EachInOrder(EachHandle handle)
        {
            if (this.HasLeft()) this.left.EachInOrder(handle);
            handle(this.value);
            if (this.HasRight()) this.right.EachInOrder(handle);
        }

        public void EachPostOrder(EachHandle handle)
        {
            if (this.HasLeft()) this.left.EachPostOrder(handle);
            if (this.HasRight()) this.right.EachPostOrder(handle);
            handle(this.value);
        }

        public void EachPreOrder(EachHandle handle)
        {
            handle(this.value);
            if (this.HasLeft()) this.left.EachPreOrder(handle);
            if (this.HasRight()) this.right.EachPreOrder(handle);
        }

        public uint Height()
        {
            uint leftHight = this.HasLeft() ? this.left.Height() : 0;
            uint rightHight = this.HasRight() ? this.right.Height() : 0;
            return (leftHight >= rightHight ? leftHight : rightHight) + 1;
        }

        public bool HasLeft()
        {
            return this.left != null;
        }

        public bool HasRight()
        {
            return this.right != null;
        }

        public bool IsLeaf()
        {
            return !(this.HasLeft() || this.HasRight());
        }

        public static bool DefaultCompareHandle(T v1, T v2)
        {
            // v1 >= v2
            return Comparer<T>.Default.Compare(v1, v2) >= 0;
        }
    }
}
