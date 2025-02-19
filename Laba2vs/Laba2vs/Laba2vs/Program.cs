using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2vs
{
    class Program
    {
        static double var9(int n, double x, double result = 1)
        {
            if (n <= 0) return result;
            return var9(n - 5000, x - 5000, abc(n > 5000 ? 5000 : n, x, result));

        }
        static double abc(int n, double x, double result)
        {
            if (n == 0) return result;
            return abc(n - 1, x - 1, Math.Sqrt(x + (x - 4) * result));
        }
        static void Main(string[] args)
        {
            double result = 1, x = 6;
            Console.Write("Введите глубину:");
            int n = Convert.ToInt32(Console.ReadLine());
            result = var9(n, x + n - 1);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}