using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
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

    public class LList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public void Add(T data)
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

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head.Previous = node;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        public LList<int> Search(T data)
        {
            int k = 0;
            LList<int> result = new LList<int>();
            Node<T> current = head;
            while (current != null)
            {
                k++;
                if (current.Data.Equals(data))
                {
                    result.Add(k);
                }
                current = current.Next;
            }
            return result;
        }
        public bool Remove(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                        if (current.Next == null)
                            tail = current.Previous;
                        else current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                        else head.Previous = null; 
                    }
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public void ReplaceLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (count > 0)
            {
                if (head != tail)
                {
                    tail.Previous.Next = node;
                    node.Previous = tail.Previous;
                    tail = node;
                }
                else
                {
                    head = node;
                    tail = node;
                }
            }
        }
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
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
