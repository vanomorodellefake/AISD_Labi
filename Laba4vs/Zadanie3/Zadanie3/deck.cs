using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
    public class Deck<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public void AddEnd(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddStart(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head.Previous = node;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        public T RemoveStart()
        {
            if (count == 0) return default(T);
            T result = head.Data;
            head = head.Next;
            if (head != null)
                head.Previous = null;
            count--;
            return result;
        }
        public T RemoveEnd()
        {
            if (count == 0) return default(T);
            T result = tail.Data;
            tail = tail.Previous;
            if (tail != null)
                tail.Next = null;
            count--;
            return result;
        }
        public T ReturnStart()
        {
            if (count == 0) return default(T);
            return head.Data;
        }
        public T ReturnEnd()
        {
            if (count == 0) return default(T);
            return tail.Data;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }


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
