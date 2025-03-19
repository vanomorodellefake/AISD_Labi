using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha
{
    class main
    {
        static string vbr;  
        static LList<int> llist = new LList<int>();
        static utils utils = new utils();
        
        static void Main(string[] args)
        {
            start();
            llist = utils.MergeSort(llist);
            Console.WriteLine(string.Join(", ", llist));
            nextstep();
            Console.ReadLine();
        }
        static void start()
        {
            try
            {
                while (vbr != "1" && vbr != "2")
                {
                    vibor();
                    switch (vbr)
                    {
                        case ("1"):
                            Console.Write("Введите llist (1 3 5 10): ");
                            string text = Console.ReadLine();
                            int count = text.Length;
                            string slovo = "";
                            for (int i = 0; i < count; i++)
                            {
                                if (text[i] == ' ')
                                {
                                    llist.Add(Convert.ToInt32(slovo));
                                    slovo = "";
                                    continue;
                                }
                                else if (i == count - 1)
                                {
                                    slovo += text[i];
                                    llist.Add(Convert.ToInt32(slovo));
                                    slovo = "";
                                    continue;
                                }
                                slovo += text[i];
                            }
                            break;
                        case ("2"):
                            Console.Write("Введите через пробел длину LList, нижнюю границу, верхнюю границу: ");
                            llist = utils.RandomLListCreate(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Команда не распознана!");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Произошла ошибка! Попробуйте ещё раз.");
                start();
            }
        }
        static void vibor()
        {
            Console.WriteLine("Введите 1 для ручного ввода, 2 для случайного заполнения, exit для выхода");
            vbr = Console.ReadLine();
        }
        static void nextstep()
        {
            try
            {
                Console.Write("Введите число для поиска: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Результат бинарного поиска: " + utils.BinarySearch(llist, a));
                Console.WriteLine("Результат интерполяционного поиска: " + utils.InterpolSearch(llist, a));
            }
            catch
            {
                Console.WriteLine("Произошла ошибка! Попробуйе ещё раз!");
                nextstep();
            }
        }
    }
}
