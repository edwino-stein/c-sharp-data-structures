namespace DataStructures
{
    public class Queue<T>
    {
        private T[] data;
        public uint maxSize { get; }
        public uint size { get; private set; }
        public uint frontPointer { get; private set; }
        public uint backPointer { get; private set; }

        public Queue(uint maxSize)
        {
            this.maxSize = maxSize;
            this.size = 0;
            this.data = new T[this.maxSize];
            this.frontPointer = 0;
            this.backPointer = this.maxSize - 1;
        }

        public bool Full()
        {
            return this.size == this.maxSize;
        }

        public bool Empty()
        {
            return this.size == 0;
        }

        public T Front()
        {
            return !this.Empty() ? this.data[this.frontPointer] : default;
        }

        public T Back()
        {
            return !this.Empty() ? this.data[this.backPointer] : default;
        }

        public bool Push(T item)
        {
            if (this.Full()) return false;

            this.backPointer += 1;
            if (this.backPointer >= this.maxSize) this.backPointer = 0;

            this.data[this.backPointer] = item;
            this.size += 1;

            return true;
        }

        public bool Pop() {

            if (this.Empty()) return false;

            this.data[this.frontPointer] = default;
            this.size -= 1;

            this.frontPointer += 1;
            if (this.frontPointer >= this.maxSize) this.frontPointer = 0;

            return true;
        }
    }
}
