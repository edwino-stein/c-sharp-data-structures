namespace DataStructures
{
    public class LinkedList<T>
    {
        private class Node {
            public T value { get; set; }
            public Node? next { get; set; }
            public Node? prev { get; set; }

            public Node(T value, Node next, Node prev)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;
            }

            public Node(T value)
            {
                this.value = value;
                this.next = null;
                this.prev = null;
            }

            public bool HasNext()
            {
                return this.next != null;
            }

            public bool HasPrev()
            {
                return this.prev != null;
            }
        }

        private Node? first;
        private Node? last;
        
        public uint size { get; private set; }
        
        public LinkedList()
        {
            this.first = null;
            this.last = null;
        }

        public bool Empty()
        {
            return this.size == 0;
        }

        private Node? findNode(uint index)
        {
            if (index >= this.size) return null;

            Node node = this.first;
            for (uint i = 0; i < index; ++i)
            {
                if (!node.HasNext()) return null;
                node = node.next;
            }

            return node;
        }

        public T First()
        {
            return this.first != null ? this.first.value : default;
        }

        public T Last()
        {
            return this.last != null ? this.last.value : default;
        }

        public T At(uint index)
        {
            Node node = this.findNode(index);
            return node != null ? node.value : default;
        }

        public bool PushBack(T value)
        {
            if (this.Empty())
            {
                this.first = new Node(value, null, null);
                this.last = this.first;
            }
            else
            {
                this.last = new Node(value, null, this.last);
                this.last.prev.next = this.last;
            }

            this.size += 1;
            return true;
        }

        public bool PushFront(T value)
        {
            if (this.Empty())
            {
                this.first = new Node(value, null, null);
                this.last = this.first;
            }
            else
            {
                this.first = new Node(value, this.first, null);
                this.first.next.prev = this.first;
            }

            this.size += 1;
            return true;
        }

        public bool Insert(T value, uint index)
        {
            if (index > this.size) return false;
            if (index == 0) return this.PushFront(value);
            if (index == this.size) return this.PushBack(value);

            Node node = this.findNode(index);
            if (node == null) return false;

            Node newNode = new Node(value, node, node.prev);
            node.prev.next = newNode;
            node.prev = newNode;
            this.size += 1;

            return true;
        }

        public bool PopFront()
        {
            if (this.Empty()) return false;

            if (this.first.HasNext())
            {
                this.first = this.first.next;
                this.first.prev = null;
            }
            else
            {
                this.first = null;
                this.last = null;
            }

            this.size -= 1;
            return true;
        }

        public bool PopBack()
        {
            if (this.Empty()) return false;
            if (this.last.HasPrev())
            {
                this.last = this.last.prev;
                this.last.next = null;
            }
            else
            {
                this.first = null;
                this.last = null;
            }

            this.size -= 1;
            return true;
        }

        public bool Remove(uint index)
        {
            if (index >= this.size) return false;
            if (index == 0) return this.PopFront();
            if (index == this.size - 1) return this.PopBack();

            Node node = this.findNode(index);
            if (node == null) return false;

            node.prev.next = node.next;
            node.next.prev = node.prev;

            this.size -= 1;
            return true;
        }

        public delegate void EachHandle(T value, uint index);

        public void Each(EachHandle handle, bool reverse = false)
        {
            if (this.Empty()) return;

            if (!reverse)
            {
                Node node = this.first;
                uint i = 0;
                while (node != null)
                {
                    handle(node.value, i++);
                    node = node.next;
                }
            }
            else {
                Node node = this.last;
                uint i = this.size - 1;
                while (node != null)
                {
                    handle(node.value, i--);
                    node = node.prev;
                }
            }   
        }
    }
}
