using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie1var1
{
    class main
    {
        static utils utils = new utils();
        static RandomArray randomArray = new RandomArray();
        static string vbr;
        static string filepath = "chisla.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Эта программа по чтению цифр из файла и их размещение в очереди по особому правилу.");
            Console.WriteLine("Правило заключается в том, что из очереди на консоль выводятся числа, меньшие a, затем числа из отрезка [a,b] и остальные.");
            Console.WriteLine("Введите 1 для записи файла, 2 для работы самой программы, exit для выхода.");
            vibor();
            while (vbr != "exit")
            {
                switch (vbr)
                {
                    case ("1"):
                        string text = "";
                        Console.Write("Введите 1, если хотите сформировать файл случайно, 2, если вручную: ");
                        string vbr2 = Console.ReadLine();
                        if (vbr2 == "1")
                        {
                            int l=0, a=0, b=0;
                            try
                            {
                                Console.Write("Введите количество чисел: ");
                                l = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите нижнюю границу: ");
                                a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите количество чисел: ");
                                b = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                errorcase();
                                break;
                            }
                            if (a > b)
                            {
                                ab();
                                break;
                            }
                            int[] rarray = randomArray.CreateRandomArray(l, a, b);
                            foreach (int x in rarray)
                                text += Convert.ToString(x) + " ";
                        }
                        else if (vbr2 == "2")
                        {
                            Console.Write("Введите числа (пример: 1 5 10 13 -5): ");
                            text = Console.ReadLine();
                            //string[] text = (Console.ReadLine()).Split( new char[] { ' ' });
                        }
                        else
                        {
                            errorcase();
                            break;
                        }
                        File.WriteAllText(filepath, text);
                        break;
                    case ("2"):
                        if (File.Exists(filepath))
                        {
                            int a=0, b=0;
                            try
                            {
                                Console.Write("Введите число a: ");
                                a = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите число b: ");
                                b = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                errorcase();
                            }
                            if (a > b)
                            {
                                ab();
                                break;
                            }
                            Ochered<int> news = utils.ReadFile(filepath);
                            int colvo = news.Count;
                            Ochered<int> res1 = new Ochered<int>();
                            Ochered<int> res2 = new Ochered<int>();
                            for (int i = 1; i <= colvo; i++)
                            {
                                int znach = news.RemoveFirst();
                                if (znach < a)
                                    Console.Write(Convert.ToString(znach) + " ");
                                else if (znach >= a && znach <= b)
                                    res1.AddLast(znach);
                                else
                                    res2.AddLast(znach);
                            }
                            foreach (int i in res1)
                                Console.Write(Convert.ToString(res1.RemoveFirst()) + " ");
                            foreach (int i in res2)
                                Console.Write(Convert.ToString(res2.RemoveFirst()) + " ");
                            Console.Write("\n");
                        }
                        else
                            Console.WriteLine("Файл не существует!");
                        break;
                    default:
                        Console.WriteLine("Команда не найдена.");
                        break;
                }
                vibor();
            }
        }
        static void vibor()
        {
            Console.Write("Введите команду: ");
            vbr = Console.ReadLine();
        }
        static void errorcase()
        {
            Console.WriteLine("Неверный ввод значения!");
        }
        static void ab()
        {
            Console.WriteLine("a больше чем b!");
        }
    }
}
