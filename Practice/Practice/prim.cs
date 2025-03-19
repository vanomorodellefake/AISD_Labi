using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class prim
    {
        public static int Prim(string name1, string name2, Graph graph)
        {
            List<Node> ostNodes = new List<Node>();
            Dictionary<Node, int> minRoads = new Dictionary<Node, int>();
            Dictionary<Node, Node> nazadNodes = new Dictionary<Node, Node>();


            Node startNode = graph.Search(name1);
            Node endNode = graph.Search(name2);

            ostNodes.Add(startNode);

            foreach (var x in startNode.Links)
            {
                minRoads[x.Key] = x.Value;
                nazadNodes[x.Key] = startNode;
            }

            int minCost = 0;

            while (ostNodes.Count < graph.Count)
            {
                Node minNode = null;
                int minValue = int.MaxValue;

                foreach (var node in graph.ReturnNodes())
                {
                    if (!ostNodes.Contains(node) && minRoads.ContainsKey(node) && minRoads[node] < minValue)
                    {
                        minValue = minRoads[node];
                        minNode = node;
                    }
                }

                if (minNode == null) break;

                ostNodes.Add(minNode);
                minCost += minValue;

                if (minNode == endNode)
                    return minCost;

                foreach (var link in minNode.Links)
                {
                    if (!ostNodes.Contains(link.Key) && (!minRoads.ContainsKey(link.Key) || link.Value < minRoads[link.Key]))
                    {
                        minRoads[link.Key] = link.Value;
                        nazadNodes[link.Key] = minNode;
                    }
                }
            }
            return minCost;
        }
    }
}
