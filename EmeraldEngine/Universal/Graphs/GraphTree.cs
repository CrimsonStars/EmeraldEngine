namespace EmeraldEngine.Universal.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GraphTree<T>
    {
        private Node<T>? StartingNode {  get; set; }

        #region Constructors

        public GraphTree()
        {
            StartingNode = null;
        }

        public GraphTree(Node<T> start)
        {
            StartingNode = start;
        }

        #endregion Constructors

        public Node<T>? SearchForNodeWithValue(char t)
        {
            var numberOfSteps = 0;
            var visited = new Stack<Node<T>>();
            var stack = new Stack<Node<T>>();
            stack.Push(StartingNode);

            while (stack.Any())
            {
                var currentNode = stack.Pop();
                visited.Push(currentNode);
                numberOfSteps++;

                if (currentNode.NodeValue.Equals(t))
                {
                    return currentNode;
                }

                foreach (var item in currentNode.Children)
                {
                    stack.Push(item);
                }
            }

            return null;
        }
    }
}