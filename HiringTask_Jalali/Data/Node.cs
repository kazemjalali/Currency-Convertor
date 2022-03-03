using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringTask_Jalali.Data
{
    public class Node
    {
        public Node() { outerEdges = new List<Edge>(); }
        public string Name { get; set; }
        public List<Edge> outerEdges { get; set; }
    }
}
