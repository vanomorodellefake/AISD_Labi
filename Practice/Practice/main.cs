using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Practice
{
    class main
    {
        static deikstri deikstri = new deikstri();
        static floid floid = new floid();
        static rukzak rukzak = new rukzak();
        static graphrekurs graphrekurs = new graphrekurs();
        static prim prim = new prim();
        static bellman bellman = new bellman();
        static kruskall kruskall = new kruskall();
        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            
            graph.AddNode("1");
            graph.AddNode("2");
            graph.AddNode("3");
            graph.AddNode("4");
            graph.AddNode("5");
            graph.AddNode("6");
            graph.AddNode("7");

            graph.AddNode("8");
            graph.AddNode("9");
            graph.AddNode("10");
            graph.AddNode("11");
            Console.WriteLine(string.Join(" ", graph.ReturnNames()));
            graph.CreateRoad("1", "2", 4, false);
            graph.CreateRoad("1", "3", 6, false);
            graph.CreateRoad("2", "4", 1, false);
            graph.CreateRoad("3", "4", 7, false);
            graph.CreateRoad("4", "5", 2, false);
            graph.CreateRoad("4", "6", 8, false);
            graph.CreateRoad("4", "7", 12, false);
            graph.CreateRoad("5", "6", 5, true);
            graph.CreateRoad("6", "7", 3, false);

            graph.CreateRoad("7", "8", 1, false);
            graph.CreateRoad("8", "9", 1, false);
            graph.CreateRoad("9", "10", 1, false);
            graph.CreateRoad("10", "11", 1, false);
            foreach (Node x in graph)
            {
                Console.WriteLine(x.Name + ": ");
                foreach (var link in x.Links)
                    Console.WriteLine(link.Key.Name + ", " + link.Value);
            }
            Console.WriteLine();
            Console.WriteLine("ДЕИКСТРИ!");
            stopwatch.Start();
            Console.WriteLine(deikstri.Deikstri("1", "4", graph));
            Console.WriteLine(deikstri.Deikstri("1", "5", graph));
            Console.WriteLine(deikstri.Deikstri("1", "7", graph));
            Console.WriteLine(deikstri.Deikstri("3", "6", graph));
            Console.WriteLine(deikstri.Deikstri("4", "7", graph));

            stopwatch.Stop();  Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            Console.WriteLine("ФЛОЙД!");
            stopwatch.Start();
            Console.WriteLine(floid.Floid("1", "4", graph));
            Console.WriteLine(floid.Floid("1", "5", graph));
            Console.WriteLine(floid.Floid("1", "7", graph));
            Console.WriteLine(floid.Floid("3", "6", graph));
            Console.WriteLine(floid.Floid("4", "7", graph));

            stopwatch.Stop(); Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            Console.WriteLine("моё!");
            stopwatch.Start();
            Console.WriteLine(graphrekurs.GraphRekurs(graph.Search("1"), graph.Search("4")));
            Console.WriteLine(graphrekurs.GraphRekurs(graph.Search("1"), graph.Search("5")));
            Console.WriteLine(graphrekurs.GraphRekurs(graph.Search("1"), graph.Search("7")));
            Console.WriteLine(graphrekurs.GraphRekurs(graph.Search("3"), graph.Search("6")));
            Console.WriteLine(graphrekurs.GraphRekurs(graph.Search("4"), graph.Search("7")));

            stopwatch.Stop(); Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            Console.WriteLine("ПРИМ!");
            stopwatch.Start();
            Console.WriteLine(prim.Prim("1", "4", graph));
            Console.WriteLine(prim.Prim("1", "5", graph));
            Console.WriteLine(prim.Prim("1", "7", graph));
            Console.WriteLine(prim.Prim("3", "6", graph));
            Console.WriteLine(prim.Prim("4", "7", graph));

            stopwatch.Stop(); Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            Console.WriteLine("БЕЛЛМАН!");
            stopwatch.Start();
            Console.WriteLine(bellman.Bellman("1", "4", graph));
            Console.WriteLine(bellman.Bellman("1", "5", graph));
            Console.WriteLine(bellman.Bellman("1", "7", graph));
            Console.WriteLine(bellman.Bellman("3", "6", graph));
            Console.WriteLine(bellman.Bellman("4", "7", graph));

            stopwatch.Stop(); Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            Console.WriteLine("КРУСКАЛЛ!");
            stopwatch.Start();
            Console.WriteLine(kruskall.Kruskall("1", "4", graph));
            Console.WriteLine(kruskall.Kruskall("1", "5", graph));
            Console.WriteLine(kruskall.Kruskall("1", "7", graph));
            Console.WriteLine(kruskall.Kruskall("3", "6", graph));
            Console.WriteLine(kruskall.Kruskall("4", "7", graph));

            stopwatch.Stop(); Console.WriteLine($"Время: { stopwatch.Elapsed.TotalMilliseconds }"); stopwatch.Reset();

            int[] w = new int[] { 6,4,3,2,5 };
            int[] p = new int[] { 5, 3, 1, 3, 6 };
            Console.WriteLine(string.Join(", ", rukzak.Rukzak(w, p, 15)));
            Console.ReadLine();
        } 
    }
}
