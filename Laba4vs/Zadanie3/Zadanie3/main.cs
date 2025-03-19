using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class main
    {
        static Sort sort = new Sort();
        static RandomArray randomArray = new RandomArray();
        static Deck<int> deck = new Deck<int>();
        static Deck<int> deck1 = new Deck<int>();
        static Deck<int> deck2 = new Deck<int>();
        static string vbr;
        static void Main(string[] args)
        {
            main main = new main();

            Console.Write("Задайте значения для размеров первого дека, длина, нижняя граница, верхяя граница (пример: 5 1 10): ");
            string a1 = Console.ReadLine();
            deck1 = main.CreateIntDeck(a1);

            Console.Write("Задайте значения для размеров второго дека, длина, нижняя граница, верхяя граница (пример: 5 1 10): ");
            string b1 = Console.ReadLine();
            deck2 = main.CreateIntDeck(b1);

            deck = sort.Merge(deck1, deck2);

            Console.WriteLine("Общий дек: " + string.Join(", ", deck));
            Console.Write("Введите 1, если хотите упорядочить числа в порядке возрастания, 2, если в порядке убывания, 3, если хотите закрыть программу: ");
            vibor();
            switcher();
        }
        public Deck<int> CreateIntDeck(string abc)
        {
            string[] a = abc.Split(' ');
            Deck<int> mass = randomArray.CreateRandomDeck(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]));
            return mass;
        }
        static void vibor()
        {
            Console.Write("Ваша команда: ");
            vbr = Console.ReadLine();
        }
        static void switcher()
        {
            while (vbr != "3")
            {
                switch (vbr)
                {
                    case ("1"):
                        deck = sort.MergeSort(deck, true);
                        Console.WriteLine(string.Join(", ", deck));
                        break;
                    case ("2"):
                        deck = sort.MergeSort(deck, false);
                        Console.WriteLine(string.Join(", ", deck));
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }
                vibor();
            }
        }
    }
}
