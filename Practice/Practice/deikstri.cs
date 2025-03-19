using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class deikstri
    {
        public int Deikstri(string name1, string name2, Graph graph)
        {
            Node knz = graph.Search(name2);
            Node teck = graph.Search(name1);
            List<string> tecks = new List<string>();
            Dictionary<string, int> table = new Dictionary<string, int>();
            foreach (Node x in graph)
            {
                table.Add(x.Name, 2000000000);
            }
            table[name1] = 0;
            while (true)
            {
                tecks.Add(teck.Name);
                foreach (var x in teck.Links)
                {
                    int sum = table[teck.Name] + teck.Links[x.Key];
                    table[x.Key.Name] = Math.Min(table[x.Key.Name], sum);
                }
                int min = int.MaxValue;
                string poisk = "";
                foreach (var x in table)
                {
                    if (!tecks.Contains(x.Key))
                        min = Math.Min(x.Value, min);
                }
                foreach (var x in table)
                {
                    if (x.Value == min)
                        poisk = x.Key;
                }
                teck = graph.Search(poisk);
                if (teck.Name == knz.Name)
                {
                    break;
                }
            }
            return table[teck.Name];
        }
    }
}
