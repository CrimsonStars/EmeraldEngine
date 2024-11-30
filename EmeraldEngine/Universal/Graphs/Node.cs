namespace EmeraldEngine.Universal.Graphs
{
    using System.Collections.Generic;

    public class Node<T>
    {
        #region Properies

        public T NodeValue { get; set; }
        public HashSet<Node<T>> Children { get; set; }

        #endregion Properies

        public Node()
        {
            Children = new HashSet<Node<T>>();
        }

        public Node(T ElementValue) : this()
        {
            NodeValue = ElementValue;
        }

        public override string ToString()
        {
            return $"VALUE: {NodeValue.ToString()}; CHILDREN_COUNT: {Children.Count};";
        }

        public Node<T>? MejkSercz(T valju)
        {
            Node<T>? result = null;

            foreach (var nudel in Children)
            {
                if (nudel.NodeValue.Equals(valju))
                {
                    result = nudel;
                    return result;
                }

                result = nudel.MejkSercz(valju);
            }

            return result;
        }
    }
}