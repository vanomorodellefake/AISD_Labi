using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class kruskall
    {
        public static int Kruskall(string name1, string name2, Graph graph)
        {
            kruskall kruskall = new kruskall();
            Graph ostGraph = new Graph();
            foreach (var node in graph.ReturnNodes())
            {
                ostGraph.AddNode(node.Name);
            }
            List<(int weight, Node from, Node to)> Roads = new List<(int, Node, Node)>();
            foreach (var x in graph.ReturnNodes())
            {
                foreach (var y in x.Links)
                {
                    Roads.Add((y.Value, x, y.Key));
                }
            }
            Roads = Roads.OrderBy(e => e.weight).ToList();
            Dictionary<Node, Node> parent = new Dictionary<Node, Node>();
            Node Find(Node node)
            {
                if (!parent.ContainsKey(node))
                    parent[node] = node;
                if (parent[node] == node)
                    return node;
                return parent[node] = Find(parent[node]);
            }

            void Union(Node a, Node b)
            {
                Node rootA = Find(a);
                Node rootB = Find(b);
                if (rootA != rootB)
                    parent[rootA] = rootB;
            }

            foreach (var (weight, from, to) in Roads)
            {
                if (Find(from) != Find(to))
                {
                    ostGraph.CreateRoad(from.Name, to.Name, weight, false);
                    Union(from, to);
                }
            }

            return GetMinimumPath(ostGraph, name1, name2);
        }
        public static int GetMinimumPath(Graph graph, string name1, string name2)
        {
            Node startNode = graph.Search(name1);
            Node endNode = graph.Search(name2);

            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            List<Node> visited = new List<Node>();

            int DFS(Node node, int cost)
            {
                Console.WriteLine("|" + node.Name + "|");
                if (node == endNode) return cost;
                visited.Add(node);

                foreach (var x in node.Links)
                {
                    if (!visited.Contains(x.Key))
                    {
                        int result = DFS(x.Key, cost + x.Value);
                        if (result != -1) return result;
                    }
                }
                return -1;
            }
            return DFS(startNode, 0);

        }
    }
}
