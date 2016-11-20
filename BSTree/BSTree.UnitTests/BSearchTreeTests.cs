using System;
using NUnit.Framework;
using BSTree.Class;

namespace BSTree.UnitTests
{
    [TestFixture]
    public class BSearchTreeTests
    {
        BSearchTree bsTree;

        [Test]
        public void BST_Size()
        {
            Assert.AreEqual(9, bsTree.Size);
        }

        [Test]
        public void BST_Height() 
        {
            Assert.AreEqual(4, bsTree.Height());
        }
        [Test]
        public void BST_InsertNode_GainNodeCount() 
        {
            bsTree.Insert(1, 9);
            Node leftNode = bsTree.MinKeyNode();
            Assert.AreEqual(1, leftNode.Key);
            Assert.AreEqual(9, leftNode.Value);
            Assert.AreEqual(10, bsTree.Size);       
        }

        [Test]
        public void BST_InsertNode_UpdateNodeValue() 
        {
            bsTree.Insert(10, 11);
            Node leftNode = bsTree.MinKeyNode();
            Assert.AreEqual(10, leftNode.Key);
            Assert.AreEqual(11 ,leftNode.Value);
            Assert.AreEqual(9, bsTree.Size);
        }

       [Test]
        public void BST_DeleteNode_DecreaseNodeCount() 
        {
            bsTree.Delete(12);
            Node leftNode = bsTree.MinKeyNode();
            Assert.AreEqual(null, leftNode.Right);            
            Assert.AreEqual( 8, bsTree.Size);
        }

       [Test]
        public void BST_FindNode() 
        {
            bool result = bsTree.Find(10);
            Assert.AreEqual(true, result);
        }

       [Test]
       public void BST_MaxKeyNode() 
       {
         Node node = bsTree.MaxKeyNode();
         Assert.AreEqual( 25, node.Key);
       }

        [SetUp]
        public void Init() 
        {
         this.bsTree = new BSearchTree();
         bsTree.Insert(20, 1);
         bsTree.Insert(15, 4);
         bsTree.Insert(25, 5);
         bsTree.Insert(10, 8);
         bsTree.Insert(18, 9);
         bsTree.Insert(12, 5);
         bsTree.Insert(17, 12);
         bsTree.Insert(16, 11);
         bsTree.Insert(19, 10);
        }

        [TearDown]
        public void Clear() 
        {
            bsTree.Clear();
        }
    }
}
