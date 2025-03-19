using System;
namespace Zadanie1
{ public class RandomArray
    {
        public Ochered<int> CreateRandomOchered(int l, int a, int b)
        {
            Random random = new Random();
            Ochered<int> och = new Ochered<int>();
            for (int i=0; i!= l; i++)
            {
                och.AddLast(random.Next(a,b+1));
            }
            return och;
        }
    }

}