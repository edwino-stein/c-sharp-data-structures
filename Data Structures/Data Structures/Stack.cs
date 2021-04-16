using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Stack<T>
    {
        private T[] data;
        private readonly uint maxSize;
        private uint pointer;

        public Stack(uint maxSize)
        {
            this.maxSize = maxSize;
            this.data = new T[maxSize + 1];
            this.pointer = 0;
        }

        public uint Size()
        {
            return this.pointer;
        }

        public uint MaxSize()
        {
            return this.maxSize;
        }

        public bool Empty()
        {
            return this.Size() == 0;    
        }

        public bool Full()
        {
            return this.Size() >= this.MaxSize();
        }

        public bool Add(T item)
        {
            if (this.Full()) return false;
            this.data[this.pointer++] = item;
            return true;
        }

        public T Top()
        {
            return !this.Empty() ? this.data[this.pointer - 1] : default;
        }

        public T Pop()
        {
            return !this.Empty() ? this.data[(pointer--) - 1] : default;
        }

    }
}
