namespace EmeraldEngine.Universal.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GraphTree<T>
    {
        public Node<T> StartingNode;

        public GraphTree(Node<T> start)
        {
            StartingNode = start;
        }
    }
}