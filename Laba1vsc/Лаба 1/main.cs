using System;
using System.Diagnostics;
using laba1;

namespace laba1
{
    class MainFile
    {
        static void Main(string[] args)
        {
            Zadanie1 zadanie1 = new Zadanie1();
            Zadanie2 zadanie2 = new Zadanie2();
            Part2 part2 = new Part2();
            RandomArray randomArray = new RandomArray();
            Stopwatch stopwatch = new Stopwatch();

            int choose;

            Console.WriteLine("Введите число в зависимости от того, какую часть программы хотите использовать. 1 - алгоритмы поиска в отсортированном массиве целых чисел, а также отдельный алгоритм поиска второго по величине числа в массиве, 2 - алгоритмы поиска слова в тексте, 3 - алгоритмы сортировки? 4 - свободный код.");
            choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1)
            {
                Console.WriteLine("Вы выбрали алгоритмы поиска в отсортированном масиве целых чисел. Для создания массива из случайных чисел Вам будет необходимо задать значение длины массива, а также границы выбора случайных чисел, из которых будет состоять массив.");
                Console.Write("Введите значение длины массива:");
                int l = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите нижнюю границу выбора случайных чисел:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите верхнюю границу выбора случайных чисел:");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите число, которое нужно будет необходимо найти:");
                int n = Convert.ToInt32(Console.ReadLine());

                int[] array = randomArray.CreateRandomArray(l, a, b);
                Array.Sort(array);
                Console.WriteLine(string.Join(", ", array));
                int[] array1 = randomArray.CreateRandomArray(l, a, b);
                Console.WriteLine("Второй массив: " + string.Join(", ", array1));


                stopwatch.Start();
                int a1 = zadanie1.SearchBinary(array, n);
                stopwatch.Stop();
                Console.WriteLine($"Процесс бинарного поиска выполнен, индекс искомого числа: {a1}, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();

                stopwatch.Start();
                int a2 = zadanie1.InterpolSearch(array, n);
                stopwatch.Stop();
                Console.WriteLine($"Процесс бинарного поиска выполнен, индекс искомого числа: {a2}, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();

                stopwatch.Start();
                int a3 = zadanie1.SecondMax(array1);
                stopwatch.Stop();
                Console.WriteLine($"Процесс поиска второго максимального числа массива выполнен, значение искомого числа: {a3}, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();
            }
            else if (choose == 2)
            {
                string? text = "";
                bool flag = true;
                Console.WriteLine("Вы будете вводить текст вручную или он должен быть сформирован случайно? 1 - Вручную, 2 - случайно");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1) 
                {
                    Console.Write("Введите текст:");
                    text = Console.ReadLine();   
                }
                else if (a == 2)
                {
                    Console.Write("Введите длину текста:");
                    int l = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите символы (если они повторяются, то у них выше шанс появится в тексте), из которых будет состоять текст:");
                    string? symbols = Console.ReadLine();
                    if (symbols == null)
                    {
                        symbols = "";
                    }
                    text = randomArray.CreateRandomArrayOfString(l, symbols);
                }
                else 
                {
                    Console.WriteLine("Ответ не распознан.");
                    flag = false;
                }
                if ( flag == true)
                {
                    Console.Write("Введите слово:");
                    string? slovo = Console.ReadLine();
                    if (slovo == null)
                    {
                        slovo = "";
                    }
                    if (text == null)
                    {
                        text = "";
                    }
                    Console.WriteLine(text);
                    Console.WriteLine(slovo);
                    stopwatch.Start();
                    int[] a1 = zadanie2.KMP(text, slovo);
                    stopwatch.Stop();
                    Console.WriteLine($"Процесс поиска слова методом MKP выполнен, значения индексов начала слов: {string.Join(", ", a1)}, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                    stopwatch.Reset();

                    stopwatch.Start();
                    int[] a2 = zadanie2.BM(text, slovo);
                    stopwatch.Stop();
                    Console.WriteLine($"Процесс поиска слова методом BM выполнен, значения индексов начала слов: {string.Join(", ", a2)}, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                    stopwatch.Reset();
                }
                

            }
            else if (choose == 3)
            {
                Console.Write("Введите значение длины массива:");
                int l = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите нижнюю границу выбора случайных чисел:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите верхнюю границу выбора случайных чисел:");
                int b = Convert.ToInt32(Console.ReadLine());

                int[] array = randomArray.CreateRandomArray(l, a, b);

                stopwatch.Start();
                int[] a1 = part2.costil_radix(array);
                stopwatch.Stop();
                //Console.WriteLine($"Массив по разрядной: {string.Join(", ", a1)}");
                Console.WriteLine($"Процесс сортировки массива алгоритмом RadixSort выполнен, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();

                stopwatch.Start();
                int[] a2 = part2.shell(array);
                stopwatch.Stop();
                //Console.WriteLine($"Массив по шеллу: {string.Join(", ", a2)}");
                Console.WriteLine($"Процесс сортировки массива алгоритмом ShellSort выполнен, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();

                stopwatch.Start();
                int[] a3 = part2.Merge(array);
                stopwatch.Stop();
                //Console.WriteLine($"Массив по соединению: {string.Join(", ", a3)}");
                Console.WriteLine($"Процесс сортировки массива алгоритмом MergeSort выполнен, было затрачено времени на алгоритм: {stopwatch.Elapsed.TotalSeconds}.");
                stopwatch.Reset();

                if (a1.SequenceEqual(a2) && a1.SequenceEqual(a3))
                {
                    Console.WriteLine("Отсортированные массивы эквивалентны друг другу!");
                }
                else
                {
                    Console.WriteLine("Что-то пошло не так!");
                }         
            }
            else if (choose == 4)
            {
                //int[] array = randomArray.CreateRandomArray(5, -100, 100); //{ -30, 1, -5, 21, -13, 25, 19};
                //Console.WriteLine(string.Join(", ", array));
                int[] array = { -30, 1, -5, 21, -13, 25, 19};
                
                //Console.WriteLine("Массив: " + string.Join(", ", array));
                //part2.shell(array);
                Console.WriteLine(string.Join(", ", part2.shell(array)));
                //part2.Merge(array);
                //int b = -83;
                //Console.WriteLine(b % 10);


            }
            else Console.WriteLine("Число не распознано");            
        }
    }
}