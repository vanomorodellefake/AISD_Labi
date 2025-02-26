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
        static void Main(string[] args)
        {
            LList<string> Text = new LList<string>(); 
            Console.WriteLine("Данная программа добавляет в LList предложения. Если предложение оканчивается на ?, то она заменит предыдущее. Для того, чтобы закончить введите exit.");
            Vvod();
            while (text != "exit")
            {
                if ((!text.Contains("! ") && !text.Contains("? ") && !text.Contains(". ")) && (text[text.Length-1] == '.' || text[text.Length - 1] == '!' || text[text.Length - 1] == '?'))
                {
                    if (!Text.IsEmpty && text[text.Length - 1] == '?')
                        Text.ReplaceLast(text);
                    else
                        Text.Add(text);
                }
                else Console.WriteLine("Вы ввели текст, а не предложение!");

                Vvod();
            }

            Console.WriteLine("Ваш текст: " + string.Join(" ", Text));
            Console.ReadLine();
        }

        static void Vvod()
        {
            Console.Write("Введите предложение для добавления: ");
            text = Console.ReadLine();
            if (text != "exit")
                try { text = char.ToUpper(text[0]) + text.Substring(1); }
                catch { }
            if (text == "")
            {
                Console.WriteLine("Вы ввели пустое значение!");
                Vvod();
            }
        }
    }
}
