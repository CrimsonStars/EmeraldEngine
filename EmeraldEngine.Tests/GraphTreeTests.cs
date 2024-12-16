namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Universal.Graphs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GraphTreeTests
    {
        #region Private properties

        private GraphTree<char>? SampleGraphTree;

        #endregion Private properties

        private void ConstructGraphTreeForTests()
        {
            // A -> [B, C]
            // B -> [D]
            // C -> [E, F, I]
            // E -> G -> H

            var firstNode = new Node<char>('A');
            var secondNode = new Node<char>('B');
            var thirdNode = new Node<char>('C');
            var fourthNode = new Node<char>('D');
            var fifthNode = new Node<char>('E');
            var sixthNode = new Node<char>('F');
            var seventhNode = new Node<char>('G');
            var eighthNode = new Node<char>('H');
            var ninthNode = new Node<char>('I');

            fifthNode.Children.Add(seventhNode);
            secondNode.Children.Add(fourthNode);
            seventhNode.Children.Add(eighthNode);

            firstNode.AddChildren(secondNode, thirdNode);
            thirdNode.AddChildren(fifthNode, sixthNode, ninthNode);

            SampleGraphTree = new GraphTree<char>(firstNode);
        }

        [TestMethod]
        [DataRow('A')]
        [DataRow('B')]
        [DataRow('C')]
        [DataRow('D')]
        [DataRow('E')]
        [DataRow('F')]
        [DataRow('G')]
        [DataRow('H')]
        [DataRow('I')]
        public void Given_Graph_When_LoopInside_Then_CheckIfValueFound(char valueToSearch)
        {
            ConstructGraphTreeForTests();

            // insert loop in the graph
            SampleGraphTree.SearchForNodeWithValue('D').Children.Add(new Node<char>('B'));

            var foundNode = SampleGraphTree.SearchForNodeWithValue(valueToSearch);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(valueToSearch, foundNode.NodeValue);
        }

        [TestMethod]
        [DataRow('A')]
        [DataRow('B')]
        [DataRow('C')]
        [DataRow('D')]
        [DataRow('E')]
        [DataRow('F')]
        [DataRow('G')]
        [DataRow('H')]
        [DataRow('I')]
        public void Given_NodeValueToFind_When_SearchTreeWithLoop_Then_CheckIfFound(char valueToSearch)
        {
            ConstructGraphTreeForTests();

            var foundNode = SampleGraphTree.SearchForNodeWithValue(valueToSearch);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(valueToSearch, foundNode.NodeValue);
        }

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void Given_SampleGraphWithLoop_When_SearchForNonexistendNode_Then_ReturnNull(bool addLoop)
        {
            ConstructGraphTreeForTests();

            if (addLoop)
            {
                // insert loop in the graph
                SampleGraphTree.SearchForNodeWithValue('D').Children.Add(new Node<char>('B'));
            }

            var result = SampleGraphTree.SearchForNodeWithValue('x');
            Assert.IsNull(result);
        }
    }
}