using EmeraldEngine.Models;
using EmeraldEngine.Universal.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmeraldEngine.Tests;

[TestClass]
public class GraphTreeTests
{

    [TestMethod]
    public void Given_GraphNode_When_CratingDefailtNodeWithInt_Then_CheckValue()
    {
        var testNode = new Node<int>();

        Assert.IsNotNull(testNode.Children);
        Assert.IsTrue(!testNode.Children.Any());
        Assert.AreEqual(0, testNode.NodeValue);
    }

    [TestMethod]
    public void Given_GraphNode_When_NodeValueIsSimpleObject_Then_CheckValue()
    {
        var testValue = 'A';
        var testNode = new Node<char>(testValue);

        Assert.IsNotNull(testNode.Children);
        Assert.IsTrue(!testNode.Children.Any());
        Assert.IsTrue(testNode.NodeValue == testValue);
    }

    [TestMethod]
    public void Given_GraphNode_When_NodeValueIsClassObject_Then_CheckValue()
    {
        var testNode = new Node<Item>();

        Assert.IsNotNull(testNode.Children);
        Assert.IsTrue(!testNode.Children.Any());
        Assert.IsNull(testNode.NodeValue);
    }

    [TestMethod]
    public void Given_TestGraphNode_When_CreatingChildrenNodes_Then_CheckIfCorrect()
    {
        var testNode = new Node<char>('A');
        testNode.Children.Add(new Node<char>('b'));
        testNode.Children.Add(new Node<char>('c'));
        testNode.Children.Add(new Node<char>('d'));

        var anyChildrenHasValueB = testNode.Children.Any(c => c.NodeValue.Equals('b'));
        var anyChildrenHasValueC = testNode.Children.Any(c => c.NodeValue.Equals('c'));
        var anyChildrenHasValueD = testNode.Children.Any(c => c.NodeValue.Equals('d'));
        var anyChildrenHasValueNotUsed = !testNode.Children.Any(c => c.NodeValue.Equals('x'));

        Assert.IsNotNull(testNode.Children);
        Assert.IsTrue(testNode.Children.Any());
        Assert.IsTrue(anyChildrenHasValueB);
        Assert.IsTrue(anyChildrenHasValueC);
        Assert.IsTrue(anyChildrenHasValueD);
        Assert.IsTrue(anyChildrenHasValueNotUsed);
    }

    [TestMethod]
    public void Given_TestGraphNode_When_CreatingChildrenNodes_Then_CheckIfHasUnexpectedValuesNodes()
    {
        var testNode = new Node<char>('A');
        testNode.Children.Add(new Node<char>('a'));

        Assert.IsNotNull(testNode.Children);
        Assert.IsTrue(testNode.Children.Any());
        Assert.IsTrue(testNode.Children.Any(c => c.NodeValue.Equals('a')));
        Assert.IsTrue(!testNode.Children.Any(c => c.NodeValue.Equals('x')));
    }
}
