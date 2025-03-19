using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class bellman
    {
        public static int Bellman(string name1, string name2, Graph graph)
        {
            Dictionary<Node, int> Roads = new Dictionary<Node, int>();
            Dictionary<Node, Node> nazadNodes = new Dictionary<Node, Node>();

            foreach (var node in graph.ReturnNodes())
            {
                Roads[node] = int.MaxValue;
            }

            Node startNode = graph.Search(name1);
            Node endNode = graph.Search(name2);
            Roads[startNode] = 0;

            int V = graph.Count;

            for (int i = 0; i < V - 1; i++)
            {
                foreach (var node in graph.ReturnNodes())
                {
                    foreach (var link in node.Links)
                    {
                        Node neighbor = link.Key;
                        int weight = link.Value;

                        if (Roads[node] != int.MaxValue && Roads[node] + weight < Roads[neighbor])
                        {
                            Roads[neighbor] = Roads[node] + weight;
                            nazadNodes[neighbor] = node;
                        }
                    }
                }
            }

            return Roads[endNode];
        }
    }
}
