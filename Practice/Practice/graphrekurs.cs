using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class graphrekurs
    {
        static List<int> Roads = new List<int>();
        public void Vpered(Node x, Node end, List<Node> visited = null, int res = 0)
        {
            if (visited == null)
            {
                visited = new List<Node>();
                Roads = new List<int>();
            }
            if (x == end)
            {
                Roads.Add(res);
                return;
            }
            visited.Add(x);

            foreach (var y in x.Links)
            {
                if (!visited.Contains(y.Key))
                {
                    Vpered(y.Key, end, visited, res + y.Value);
                }
            }
            visited.Remove(x);
        }
        public int GraphRekurs(Node x, Node end)
        {
            Vpered(x, end);
            return Roads.Min();
        }
    }
}
