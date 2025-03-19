using System;
namespace Zadanie3
{ public class RandomArray
    {
        public Deck<int> CreateRandomDeck(int l, int a, int b)
        {
            Random random = new Random();
            Deck<int> arr = new Deck<int>();
            for (int i=0; i!= l; i++)
            {
                arr.AddEnd(random.Next(a,b+1));
            }
            return arr;
        }
    }

}