namespace EmeraldEngine.Universal.Graphs
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Node<T>
    {
        #region Properies

        public T? NodeValue { get; set; }
        public HashSet<Node<T>> Children { get; set; }
        public bool IsActive { get; set; }

        #endregion Properies

        #region Constructors

        public Node()
        {
            NodeValue = default;
            Children = new HashSet<Node<T>>();
        }

        public Node(T ElementValue) : this()
        {
            NodeValue = ElementValue;
        }

        #endregion Constructors

        public int AddChildren(params Node<T>[] childrenNodes)
        {
            foreach (var node in childrenNodes)
            {
                Children.Add(node);
            }

            return Children.Count;
        }

        public override string ToString()
        {
            return $"VALUE: {NodeValue.ToString()}; CHILDREN_COUNT: {Children.Count};";
        }
    }
}