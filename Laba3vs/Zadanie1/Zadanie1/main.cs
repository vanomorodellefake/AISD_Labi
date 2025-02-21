using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{ 
    class main
    {

        static void Main(string[] args)
        {
            char last;
            StringLList stringLList = new StringLList();
            LList<char> llist = new LList<char>();

            Console.Write("Введите Ваше предложение, оканчивающееся точкой: ");
            string text = Console.ReadLine(); // Ввод предложения
            if (text.Length > 0)
                last = text[text.Length - 1];
            else
                last = ' '; 
            
            if ((last != '.') && (last != '?') && (last != '!')) Console.WriteLine("Ваше предложение не оканчивается точкой! Какой нехороший человек.");
            llist = stringLList.preobrazovatel(text);

            
            Console.WriteLine("Ваше предложение, разделённое на символы: " + string.Join(", ", llist) + ".");

            Console.WriteLine("Теперь Вам доступнен функционал программы для работы с листом, введите число, что будет определять действие. Введите help для демонстрации команд.");



            /*  1. Добавление элемента в конец списка.
                2. Добавление элемента в начало списка.
                3. Добавление элемента в определенную позицию.
                4. Удаление элемента по его значению.
                5. Удаление элемента по его номеру в односвязном списке.
                6. Очистка списка.
                7. Поиска номера элемента в списке.
                8. Просмотр списка.
            */
            Console.Write("Введите номер команды: ");
            string vibor = Console.ReadLine();
            while (vibor != "9")
            {
                
                switch (vibor)
                {
                    case "help":
                        Console.WriteLine("1. Добавление элемента в конец списка.");
                        Console.WriteLine("2. Добавление элемента в начало списка.");
                        Console.WriteLine("3. Добавление элемента в определенную позицию.");
                        Console.WriteLine("4. Удаление элемента по его значению.");
                        Console.WriteLine("5. Удаление элемента по его номеру в односвязном списке.");
                        Console.WriteLine("6. Очистка списка.");
                        Console.WriteLine("7. Поиска номера элемента в списке.");
                        Console.WriteLine("8. Просмотр списка.");
                        Console.WriteLine("9. Покинуть бесмысленный цикл.");
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Введите символ/слово для добавления в конец: ");
                            string slovo = Console.ReadLine();
                            foreach (char x in slovo)
                            {
                                llist.Add(x);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Введите символ для добавления: ");
                            llist.AppendFirst(Convert.ToChar(Console.ReadLine()));
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Введите позицию для добавления: ");
                            int nn = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите символ для добавления: ");
                            string a = Console.ReadLine();
                            foreach (char x in a)
                            {
                                llist.AddN(x, nn);
                                nn++;
                            }      
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Введите символ для удаления: ");
                            char a = Convert.ToChar(Console.ReadLine());
                            if (llist.Contains(a))
                                llist.Remove(a);
                            else
                                Console.WriteLine("Символ не найден!"); 
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "5":
                        //try
                        //{
                            Console.Write("Введите номера символов для удаления через запятую: ");
                            string n = Console.ReadLine();
                            LList<int> z = stringLList.ToInt(n);

                            foreach (int x in z)
                            {
                                if (llist.RemoveN(x)) Console.WriteLine($"Значение на позиции {x} удалено.");
                                else Console.WriteLine($"Значение на позиции {x} не найдено.");
                            }
                            
                        //}
                        //catch
                        //{
                         //   Console.WriteLine("Произошла ошибка!");
                        //}
                        break;
                    case "6":
                        try
                        {
                            llist.Clear();
                            Console.WriteLine("Список очищен!");
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "7":
                        try
                        {
                            Console.Write("Введите символ для поиска: ");
                            char a = Convert.ToChar(Console.ReadLine());
                            LList<int> check = llist.Search(a);
                            foreach (int x in check)
                            {
                                Console.Write(x);
                                Console.Write(", ");
                            }
                                
                        }
                        catch
                        {
                            Console.WriteLine("Произошла ошибка!");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Ваш список: " + string.Join(", ", llist) + ".");
                        break;
                }
                Console.Write("Введите номер команды: ");
                vibor = Console.ReadLine();
            }
            
            Console.ReadLine();
        }
    }
}
