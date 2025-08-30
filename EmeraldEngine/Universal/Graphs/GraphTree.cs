namespace EmeraldEngine.Universal.Graphs
{
    using System.Collections.Generic;
    using System.Linq;

    public class GraphTree<T>
    {
        private Node<T>? StartingNode { get; set; }

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

        public Node<T>? SearchForNodeWithValue(T t, bool ignoreNonActiveNodes)
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
                    if (item.IsActive || ignoreNonActiveNodes)
                    {
                        stack.Push(item);
                    }
                }
            }

            return null;
        }

        public Node<T>? SearchForNodeWithValue(T valueToSeek)
        {
            return SearchForNodeWithValue(valueToSeek, false);
        }

        public Node<T>? SearchForNodeWithValueIgnoreNonActiveNodes(T valueToSeek)
        {
            return SearchForNodeWithValue(valueToSeek, true);
        }
    }
}