using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha
{
    class utils
    {
        public LList<int> CreateRandomLList(int l, int a, int b)
        {
            Random random = new Random();
            LList<int> arr = new LList<int>();
            for (int i = 0; i != l; i++)
            {
                arr.Add(random.Next(a, b + 1));
            }
            return arr;
        }
        public int BinarySearch(LList<int> llist, int x)
        {
            int m, left = 0, right = llist.Count - 1;
            do
            {
                m = (left + right) / 2;
                if (x > llist.ReturnZnachPos(m))
                    left = m+1;
                else
                    right = m-1;
            }
            while (llist.ReturnZnachPos(m) != x && left <= right);

            if (llist.ReturnZnachPos(m) == x)
                return m;
            else
                return -1;
        }
        public int InterpolSearch(LList<int> llist, int x)
        {
            int mid, left = 0, right = llist.Count - 1;
            while ((llist.ReturnZnachPos(left) <= x) && (llist.ReturnZnachPos(right) >= x))
            {
                mid = left + ((x - llist.ReturnZnachPos(left)) * (right - left)) / (llist.ReturnZnachPos(right) - llist.ReturnZnachPos(left));
                if (llist.ReturnZnachPos(mid) < x) right = mid + 1;
                else if (llist.ReturnZnachPos(mid) > x) right = mid - 1;
                else return mid;
            }
            if (llist.ReturnZnachPos(left) == x) return left;
            else return -1;
        }
        public LList<int> RandomLListCreate(string abc)
        {
            string[] abc1 = abc.Split();
            return CreateRandomLList(Convert.ToInt32(abc1[0]), Convert.ToInt32(abc1[1]), Convert.ToInt32(abc1[2]));
        }
        public LList<int> MergeSort(LList<int> deck)
        {
            if (deck.Count <= 1) return deck;
            int count = deck.Count;
            int middle = count / 2;
            LList<int> left = new LList<int>();
            LList<int> right = new LList<int>();
            LList<int> result = new LList<int>();

            for (int z = 1; z <= middle; z++)
                left.Add(deck.RemoveStart());
            for (int z = middle + 1; z <= count; z++)
                right.Add(deck.RemoveStart());

            left = MergeSort(left);
            right = MergeSort(right);

            
            int i = 0, j = 0, Lcount = left.Count, Rcount = right.Count;
            while (i < Lcount && j < Rcount)
            {
                if (left.ReturnStart() < right.ReturnStart())
                {
                    result.Add(left.RemoveStart());
                    i++;
                }
                else
                {
                    result.Add(right.RemoveStart());
                    j++;
                }
            }
            while (i < Lcount)
            {
                result.Add(left.RemoveStart());
                i++;
            }
            while (j < Rcount)
            {
                result.Add(right.RemoveStart());
                j++;
            }
            return result;
        }
    }
}
