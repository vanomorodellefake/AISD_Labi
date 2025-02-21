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
    public class LList<T>:IEnumerable<T>
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
                tail.Next = node;
            tail = node;
            count++;
        }

        public bool AddN(T data, int n)
        {
            if (n > count) return false;
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            Node<T> previous = null;
            
            for (int i=1;i<n;i++)
            {
                previous = current;
                current = current.Next;
            }
            if (previous != null)
            {
                node.Next = current;
                previous.Next = node;
            }
            else
            {
                node.Next = current;
                head = node;
            }
            count++;
            return true;
        }
        /*
        public void Sort(LList<int> list)
        {
            Node<int> current = head;
            Node<int> previous = null;
            for (int a = 1; a <= list.Count; a++)
                for (int b = 1; b <= list.Count; b++)
                {
                    if (current < current.Next)

                }
        }
        */
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
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
           
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveN(int n)
        {
            if (n > count) return false;
            Node<T> current = head;
            Node<T> previous = null;
            
            for (int i = 1; i < n; i++)
            {
                previous = current;
                current = current.Next;
            }

            if (previous != null)
            {
                previous.Next = current.Next;

                if (current.Next == null)
                    tail = previous;
                count--;
                return true;
            }
            else
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                count--;
                return true;
            }
            return false;
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

        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
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
