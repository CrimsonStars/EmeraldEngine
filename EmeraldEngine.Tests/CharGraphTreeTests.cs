namespace EmeraldEngine.Tests
{
    using EmeraldEngine.Universal.Graphs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CharGraphTreeTests
    {
        #region Private properties

        private static GraphTree<char>? SampleGraphTree;

        #endregion Private properties

        private static void ConstructGraphTreeForTests()
        {
            // A -> [B, C]
            // B -> [D]
            // C -> [E, F, I]
            // E -> G -> H
            // H -> I (not active)

            var firstNode = new Node<char>('A');
            var secondNode = new Node<char>('B');
            var thirdNode = new Node<char>('C');
            var fourthNode = new Node<char>('D');
            var fifthNode = new Node<char>('E');
            var sixthNode = new Node<char>('F');
            var seventhNode = new Node<char>('G');
            var eighthNode = new Node<char>('H');
            var ninthNode = new Node<char>('I', false);

            fifthNode.Children.Add(seventhNode);
            secondNode.Children.Add(fourthNode);
            seventhNode.Children.Add(eighthNode);
            eighthNode.Children.Add(ninthNode);

            firstNode.AddChildren(secondNode, thirdNode);
            thirdNode.AddChildren(fifthNode, sixthNode, ninthNode);

            SampleGraphTree = new GraphTree<char>(firstNode);
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ConstructGraphTreeForTests();
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
        public void Given_Graph_When_LoopInside_Then_CheckIfValueFound(char valueToSearch)
        {
            // insert loop in the graph
            SampleGraphTree.SearchForNodeWithValueIgnoreNonActiveNodes('D').Children.Add(new Node<char>('B'));

            var foundNode = SampleGraphTree.SearchForNodeWithValue(valueToSearch);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(valueToSearch, foundNode.NodeValue);
        }

        [TestMethod]
        public void Given_Graph_When_SearchedNodeNonActive_Then_CheckIfValueFound()
        {
            var nonActiveNodeToSeach = 'I';
            var foundNode = SampleGraphTree.SearchForNodeWithValue(nonActiveNodeToSeach);

            Assert.IsNull(foundNode);
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
            var foundNode = SampleGraphTree.SearchForNodeWithValueIgnoreNonActiveNodes(valueToSearch);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(valueToSearch, foundNode.NodeValue);
        }

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void Given_SampleGraphWithLoop_When_SearchForNonexistendNode_Then_ReturnNull(bool addLoop)
        {
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