using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Sort
    {
        public Deck<int> MergeSort(Deck<int> deck, bool check=true)
        {
            if (deck.Count <= 1) return deck;
            int count = deck.Count;
            int middle = count / 2;
            Deck<int> left = new Deck<int>();
            Deck<int> right = new Deck<int>();
            Deck<int> result = new Deck<int>();

            for (int z = 1; z <= middle; z++)
                left.AddEnd(deck.RemoveStart());
            for (int z = middle + 1; z <= count; z++)
                right.AddEnd(deck.RemoveStart());

            left = MergeSort(left, check);
            right = MergeSort(right, check);

            if (check)
            {
                int i = 0, j = 0, Lcount = left.Count, Rcount = right.Count;
                while (i < Lcount && j < Rcount)
                {
                    if (left.ReturnStart() < right.ReturnStart())
                    {
                        result.AddEnd(left.RemoveStart());
                        i++;
                    }
                    else
                    {
                        result.AddEnd(right.RemoveStart());
                        j++;
                    }
                }
                while (i < Lcount)
                {
                    result.AddEnd(left.RemoveStart());
                    i++;
                }
                while (j < Rcount)
                {
                    result.AddEnd(right.RemoveStart());
                    j++;
                }

                return result;
            }
            else
            {
                int i = 0, j = 0, Lcount = left.Count, Rcount = right.Count;
                while (i < Lcount && j < Rcount)
                {
                    if (left.ReturnStart() > right.ReturnStart())
                    {
                        result.AddEnd(left.RemoveStart());
                        i++;
                    }
                    else
                    {
                        result.AddEnd(right.RemoveStart());
                        j++;
                    }
                }
                while (i < Lcount)
                {
                    result.AddEnd(left.RemoveStart());
                    i++;
                }
                while (j < Rcount)
                {
                    result.AddEnd(right.RemoveStart());
                    j++;
                }

                return result;
            }
        }
        public Deck<int> Merge(Deck<int> deck1, Deck<int> deck2)
        {
            Deck<int> deck = new Deck<int>();
            while (deck1.Count > 0)
                deck.AddEnd(deck1.RemoveStart());
            while (deck2.Count > 0)
                deck.AddEnd(deck2.RemoveStart());
            return deck;
        }
        public Deck<T> MassToDeck<T>(T[] mass)
        {
            Deck<T> result = new Deck<T>();
            foreach (T x in mass)
            {
                result.AddEnd(x);
            }
            return result;
        }
    }
}
