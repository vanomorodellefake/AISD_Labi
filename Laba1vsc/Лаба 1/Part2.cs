using System.Globalization;
using System.IO.Pipelines;
using System.Threading.Tasks.Dataflow;

namespace laba1
{public class Part2
    {
        public int[] costil_radix(int[] array)
        {
            int n = array.Length;
            List<int> plus = new List<int>();
            List<int> minus = new List<int>();
            for (int i=0; i<n; i++)
            {
                if (array[i] >= 0) plus.Add(array[i]);
                else minus.Add(array[i]);
            }
            int[] plusarray = plus.ToArray();
            int[] minusarray = minus.ToArray();
            for (int i=0;i<minusarray.Length;i++)
                minusarray[i] = Math.Abs(minusarray[i]);
            plusarray = radix(plusarray);
            if (minusarray.Length>0)
                minusarray = radix(minusarray);

            for (int i=0;i<minusarray.Length;i++)
                minusarray[i] = minusarray[i]*-1;

            Array.Reverse(minusarray);

            int[] result = new int[plusarray.Length + minusarray.Length];
            int n1 = minusarray.Length;
            int n2 = plusarray.Length;
            int n3 = result.Length;
            
            //for (int i=0;i<n1;i++)
            //    result[i] = minusarray[i];

            //for (int i=0;i<n2;i++)
            //    result[n1+i] = plusarray[i];
            if (minusarray.Length>0)
                Array.Copy(minusarray, 0, result, 0, n1);
            Array.Copy(plusarray, 0, result, n1, n2);

            return result;
        }

        public int[] radix(int[] array)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            int max = array.Max();

            for (int exponent = 1; max/exponent > 0; exponent *= 10)
            {
                for (int i = 0; i < n; i++)
                {
                    //Console.WriteLine(array[i]);
                    //Console.WriteLine(array[i]/exponent);
                    //Console.WriteLine((array[i] / exponent) % 10);
                    count[Math.Abs((array[i] / exponent) % 10)]++;
                }

                //Console.WriteLine("Числа рязрядов: " + string.Join(", ", count));

                for (int i = 1; i < 10; i++)
                    count[i] += count[i - 1]; // префиксная сумма

                //Console.WriteLine("Префиксная сумма: " + string.Join(", ", count));

                for (int i = n - 1; i >= 0; i--)
                {
                    output[count[Math.Abs((array[i] / exponent) % 10)] - 1] = array[i];
                    count[Math.Abs((array[i] / exponent) % 10)]--;
                }

                //Console.WriteLine("count итог: " + string.Join(", ", count));
                //Console.WriteLine("Вывод: " + string.Join(", ", output));

                for (int i = 0; i < n; i++)
                    array[i] = output[i];

                Array.Clear(count, 0, 10);
            }
            return array;
        }
        public int[] shell(int[] array)
        {
            int n = array.Length;
            int step = n/2;
            while (step >= 1)
            {
                int k = step;
                for (int i = k; i<n; i++)
                {
                    //Console.WriteLine($"Массив: {string.Join(", ", array)}");
                    int tmp = array[i];
                    int j = i-k;
                    //Console.WriteLine($"i: {i}, k: {k}, tmp: {tmp}, j: {j}");
                    while ((j>=0) && (tmp < array[j]))
                    {
                        array[j+k]=array[j];
                        j=j-k;
                        //Console.WriteLine($"j: {j}");
                    }
                    array[j+k]=tmp;
                }
                step = 3*step/5;
            }
            return array;
        } 
        public int[] Merge(int[] array)
        {
            //Console.WriteLine("Новый заход!");

            if (array.Length <= 1) return array;

            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            //Console.WriteLine($"left: {string.Join(", ", left)}, right: {string.Join(", ", right)}");

            left = Merge(left);
            right = Merge(right);

            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                //Console.WriteLine($"Сравнение из left {left[i]} и из right {right[j]}");
                if (left[i] < right[j])
                {
                    result[k++] = left[i++];
                    //Console.WriteLine($"Добавлено в Result: {string.Join(", ", result)}");
                }
                else
                {
                    result[k++] = right[j++];
                    //Console.WriteLine($"Добавлено в Result: {string.Join(", ", result)}");
                }
            }
            while (i < left.Length)
            {
                //Console.WriteLine($"Просто добавляем из left {left[i]}");
                result[k++] = left[i++];
                //Console.WriteLine($"Добавлено в Result: {string.Join(", ", result)}");
            }
            while (j < right.Length)
            {
                //Console.WriteLine($"Просто добавляем из right {right[j]}");
                result[k++] = right[j++];
                //Console.WriteLine($"Добавлено в Result: {string.Join(", ", result)}");
            }

            return result;
        }
    }
}