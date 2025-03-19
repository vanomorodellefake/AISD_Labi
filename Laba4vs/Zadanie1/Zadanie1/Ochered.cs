using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class Ochered<T>: IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }
        public void RemoveFirst()
        {
            if (head == null) return;
            head = head.Next;
            if (head == null)
                tail = null;
            count--;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
