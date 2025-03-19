using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class main
    {
        static string text;
        static string textvs;
        static void Main(string[] args)
        {
            Console.WriteLine("Это программа по проверке строки на палиндром. Введите exit для выхода");
            while (text != "exit")
            {
                start();
                if (IsPolindrom(text))
                    Console.WriteLine("Текст является полиномом!");
                else
                    Console.WriteLine("Текст не является полиномом!");
            }
        }

        static void start()
        {
            Console.Write("Введите строку для проверки на палиндром: ");
            text = Console.ReadLine();
            text = text
                .Replace(".", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace("?", "")
                .Replace("!", "")
                .Replace(" ", "");
            if (text == "")
            {
                Console.WriteLine("Строка пуста!");
                start();
            }
            Console.WriteLine("Ваш текст после преображения: " + text);
        }
        static bool IsPolindrom(string txt)
        {
            Stek<char> checker = new Stek<char>();
            foreach (char x in txt)
            {
                checker.AddStart(x);
            }
            foreach (char x in txt)
            {
                if (x != checker.RemoveStart())
                    return false;
            }
            return true;
        }
    }
}
