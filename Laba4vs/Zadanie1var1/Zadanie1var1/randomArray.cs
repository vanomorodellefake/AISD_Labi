using System;
namespace Zadanie1var1
{ public class RandomArray
    {
        public int[] CreateRandomArray(int l, int a, int b)
        {
            Random random = new Random();
            int[] arr = new int[l];
            for (int i=0; i!= l; i++)
            {
                arr[i] = random.Next(a,b+1);
            }
            return arr;
        }
    }

}