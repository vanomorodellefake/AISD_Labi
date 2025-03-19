using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class rukzak
    {
        static List<int> result = new List<int>();
        public List<int> Rukzak(int[] w, int[] p, int W)
        {
            int k = w.Length;
            int[,] A = new int[k + 1, W + 1];
            for (int n = 0; n <= W; n++)
                A[0, n] = 0;
            for (int s = 1; s <= k; s++)
            {
                for (int n = 0; n <= W; n++)
                {
                    A[s, n] = A[s - 1, n];
                    if (n >= w[s - 1] && (A[s - 1, n - w[s - 1]] + p[s - 1] > A[s, n]))
                        A[s, n] = A[s - 1, n - w[s - 1]] + p[s - 1];
                }
            }
            Print(k, W, w, A);
            return result;
        }

        public void Print(int s, int n, int[] w, int[,] A)
        {
            if (A[s, n] == 0) return;
            else if (A[s - 1, n] == A[s, n])
                Print(s - 1, n, w, A);
            else
            {
                Print(s - 1, n - w[s - 1], w, A);
                result.Add(s);
            }
        }
    }
}
