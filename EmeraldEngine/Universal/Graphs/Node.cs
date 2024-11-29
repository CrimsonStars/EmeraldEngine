namespace EmeraldEngine.Universal.Graphs
{
    using System.Collections.Generic;

    public class Node<T>
    {
        #region Properies
        public T? NodeValue { get; set; }
        public HashSet<Node<T>> Children { get; set; }
        #endregion

        public Node()
        {
            Children = new HashSet<Node<T>>();
        }

        public Node(T ElementValue) : this()
        {
            NodeValue = ElementValue;
        }


    }
}