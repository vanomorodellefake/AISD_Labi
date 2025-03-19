using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class main
    {
        static string vibor; 
        static Ochered<int> och = new Ochered<int>();
        static void Main(string[] args)
        {
            start();
            help();
            vvod();
            cases();
        }
        static void vvod()
        {
            Console.Write("Введите команду: ");
            vibor = Console.ReadLine();
        }
        static void start()
        {
            Console.Write("Введите 1, если хотите ввести значения вручную, 2, если хотите ввести значения случайно: ");
            string vbr = Console.ReadLine();
            if (vbr == "1")
            {
                Console.Write("Введите символы (пример: 1 -30 50 10): ");
                string text = Console.ReadLine();
                int count = text.Length;
                string slovo = "";
                for (int i = 0; i<count;i++)
                {
                    if (text[i] == ' ')
                    {
                        och.AddLast(Convert.ToInt32(slovo));
                        slovo = "";
                        continue;
                    }
                    else if (i == count-1)
                    {
                        slovo += text[i];
                        och.AddLast(Convert.ToInt32(slovo));
                        slovo = "";
                        continue;
                    }
                    slovo += text[i];
                }
                Console.WriteLine(string.Join(", ", och));
            }
            else if (vbr == "2")
            {
                int n, a, b;
                Console.WriteLine("Введите значения длины, начала и конца случайного массива (пример 10 1 5): ");
                string tmp = Console.ReadLine();
                string[] tm = tmp.Split(' ');
                n = Convert.ToInt32(tm[0]); a = Convert.ToInt32(tm[1]); b = Convert.ToInt32(tm[2]);
                tm = null;
                RandomArray randomArray = new RandomArray();
                och = randomArray.CreateRandomOchered(n, a, b);
                Console.WriteLine(string.Join(", ", och));
            }
            else
                Console.WriteLine("Команда не распознана!");
        }
        static void help()
        {
            Console.WriteLine("Список команд:");
            Console.WriteLine("1 - добавить значение в конец очереди.");
            Console.WriteLine("2 - удалить значение из начала очереди.");
            Console.WriteLine("3 - очистить очередь");
            Console.WriteLine("4 - вывод очереди");
            Console.WriteLine("5 - разделение очереди на положительную и отрицательную");
            Console.WriteLine("exit - выход");
        }
        static void cases()
        {
            while (vibor != "exit")
            {
                switch (vibor)
                {
                    case "1":
                        Console.Write("Введите символ для доблавения: ");
                        int q = Convert.ToInt32(Console.ReadLine());
                        och.AddLast(q);
                        Console.WriteLine($"Символ {q} был добавлен.");
                        break;
                    case "2":
                        och.RemoveFirst();
                        Console.WriteLine("Первый символ был удалён.");
                        break;
                    case "3":
                        och.Clear();
                        Console.WriteLine("Очередь была очищена");
                        break;
                    case "4":
                        Console.WriteLine("Ваша очередь: " + string.Join(", ", och));
                        break;
                    case "5":
                        Ochered<int> och1 = new Ochered<int>();
                        Ochered<int> och2 = new Ochered<int>();
                        foreach (int x in och)
                            if (x >= 0) och1.AddLast(x);
                            else och2.AddLast(x);
                        Console.WriteLine("Ваша положительная очередь: " + string.Join(", ", och1));
                        Console.WriteLine("Ваша отрицательная очередь: " + string.Join(", ", och2));
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }
                vvod();
            }
        }
    }
}
