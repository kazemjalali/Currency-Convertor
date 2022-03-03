using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringTask_Jalali.Data
{
    public class Repository
    {
        List<Node> Graph;
        public Repository()
        {
            Graph = new List<Node>();
        }

        internal void updateGraph(IEnumerable<Tuple<string, string, double>> conversionRate)
        {
            
            foreach (var item in conversionRate)
            {
                var srcExists = NodeExist(item.Item1);
                var dstExists = NodeExist(item.Item2);
                if(srcExists)
                {
                    var edge = new Edge() { ConversionRate = item.Item3, Dst = item.Item2};
                    findNode(item.Item1).outerEdges.Add(edge);
                    
                }
                else
                {
                    var node = new Node() { Name = item.Item1};
                    var edge = new Edge() { ConversionRate = item.Item3, Dst = item.Item2 };
                    node.outerEdges.Add(edge);
                    Graph.Add(node);
                }
                if (dstExists)
                {
                    var edge = new Edge() { ConversionRate = 1 / item.Item3, Dst = item.Item1 };
                    findNode(item.Item2).outerEdges.Add(edge);
                }
                else
                {
                    var node = new Node() { Name = item.Item2 };
                    var edge = new Edge() { ConversionRate = 1 / item.Item3, Dst = item.Item1 };
                    node.outerEdges.Add(edge);
                    Graph.Add(node);
                }
            }
        }
        public Node findNode(string name)
        {
            return Graph.FirstOrDefault(a => a.Name.Equals(name));
        }


        private bool NodeExist(string item1)
        {
            foreach(var item in Graph)
                if (item.Name == item1)
                    return true;
            return false;
        }

       
        public double GetShortestPath(string src, string dest, double amount)
        {
            List<Tuple<Node, Node>> parent = new List<Tuple<Node,Node>>();
            if (BfsSearch(src, dest, ref parent) == false)
            {
                Console.WriteLine("Given source and destination are not connected");
                return -1;
            }
            List<Node> path = new List<Node>();
            Node iterator = findNode(dest);
            path.Add(iterator);
            while (iterator != findNode(src))
            {
                var currentParent = parent.FirstOrDefault(a => a.Item2 == iterator).Item1;
                path.Add(currentParent);
                iterator = currentParent;
            }
            double result = amount;
            Console.WriteLine("Conversion Path:");
            for (int i = path.Count - 1; i > 0; i--)
            {
                Console.Write(path[i].Name + " ");
                if (i == 1)
                    Console.WriteLine(path[i-1].Name);
                var exchangeRate = path[i].outerEdges.FirstOrDefault(a => a.Dst == path[i-1].Name).ConversionRate;
                result = result * exchangeRate;
            }
            return result;

        }

        public bool BfsSearch(string src, string dest, ref List<Tuple<Node, Node>> parent)
        {
            Node srcNode = findNode(src);
            Node destNode = findNode(dest);
            List<Node> queue = new List<Node>();
            List<Node> visited = new List<Node>();

            visited.Add(srcNode);
            queue.Add(srcNode);
            while(queue.Count != 0)
            {
                Node u = queue[0];
                queue.RemoveAt(0);
                for(int i = 0; i < u.outerEdges.Count; i++)
                {
                    var adjNode = findNode(u.outerEdges[i].Dst);
                    if (!visited.Contains(adjNode))
                    {
                        visited.Add(adjNode);
                        queue.Add(adjNode);
                        parent.Add(new Tuple<Node, Node>(u, adjNode));
                        if (adjNode == destNode)
                            return true;
                    }
                }
            }
            return false;
        }
       
    }
}
