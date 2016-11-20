using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSTree.Class
{
  public  class BSearchTree
    {
       private static Node root = null;

       int size = 0;

       public void Insert(int key,int value) 
       {
           Node node = new Node(key, value);
           if (root == null)
           {
               root = node;
           }
           else 
           {
               Add(node ,root);
           }
           this.size++;
       }

       private void Add(Node node, Node tree) 
       {
           if (tree == null) { return; }
           int result = node.Key.CompareTo(tree.Key);
           if (result < 0) {
               Add(node, tree.Left);
               if (tree.Left == null)
               {
                   tree.Left = node;
               }                       
           }
           if (result > 0)
           {
               Add(node, tree.Right);
               if (tree.Right == null)
               {
                   tree.Right = node;
               }
           }
           if(result == 0){ tree.Value = node.Value; this.size--; }
       }

       public bool Find(int key)
       {
           Node node = root;
           while(node != null)
           {
               int cmp = key.CompareTo(node.Key);
               if (cmp == 0) { return true; }
               if (cmp < 0) { node = node.Left; }
               if (cmp > 0) { node = node.Right; }
           }
           return false;
       }

       public Node FindParentNode(int key)
       {
           Node parent = null;
           Node node = root;
           while (node != null)
           {
               int cmp = key.CompareTo(node.Key);
               if (cmp == 0)
               {
                   return parent;
               }
               if (cmp < 0) { parent = node; node = node.Left; }
               if (cmp > 0) { parent = node; node = node.Right; }
           }
           return null;
       }

       public Node FindNode(int key, ref bool isLeft)
       {
           Node node = root;
           while (node != null)
           {
               int cmp = key.CompareTo(node.Key);
               if (cmp == 0)
               {
                   return node;
               }
               if (cmp < 0) { node = node.Left; isLeft = true; }
               if (cmp > 0) { node = node.Right; isLeft = false; }
           }
           return null;
       }
  
       public void Delete(int key) 
       {
           bool isLeft = false;
           Node parent = FindParentNode(key);
           Node node = FindNode(key, ref isLeft);

           //1.node is a leaf (without children)
           if (node.Right == null && node.Left == null)
           {
               if (isLeft)
               {
                   parent.Left = null;
               }
               else
               {
                   parent.Right = null;
               }
           }
         
           //2.node has a child
           if (node.Right != null && node.Left == null) 
           {
               //node left
               if (isLeft)
               {
                   node = node.Right;
                   parent.Left = node;
               }
               else //node right
               {
                   node = node.Right;
                   parent.Right = node;
               }
           }
           if (node.Left != null && node.Right == null)
           {
               //node left
               if (isLeft)
               {
                   node = node.Left;
                   parent.Left = node;
               }//node right 
               else 
               {
                   node = node.Left;
                   parent.Right = node;
               }
           }

           //3.node has a two childs
           if (node.Left != null && node.Right != null)
           {
              Node successor = GetSuccessor(node);
              Node parentSuccessor = FindParentNode(successor.Key);
              successor.Right = node.Right;
              successor.Left = node.Left;
              parentSuccessor.Left = null;
              if (isLeft) 
              {
                  parent.Left = successor;
              }
              else { parent.Right = successor; }
           }
           this.size--;
       }

       public Node MinKeyNode()
       {
           Node node = root;
           Node leftNode = null;
           while(node != null) 
           {
               leftNode = node;
               node = node.Left;
           }
           return leftNode;
       }

       public Node MaxKeyNode() 
       {
           return MaxKeyNode(root);
       }

       private Node MaxKeyNode(Node node)
       {
           if (node.Right == null) return node;
           else return MaxKeyNode(node.Right);
       }

       private Node GetSuccessor(Node node) 
       {
           Node nodeSuccessor = null;
           Node nodeRight = node.Right;
           while (nodeRight != null) 
           {
               nodeSuccessor = nodeRight;
               nodeRight = nodeRight.Left;
           }
           if (nodeSuccessor != null) 
           {
               return nodeSuccessor;
           }
           return null;
       }

       public int Height() { return Height(root); }

       public int Height(Node node) 
       {
         if (node == null) return -1;
         int result = 1 + Math.Max(Height(node.Left), Height(node.Right));
         return result;
       }
 
       public int Size { get { return this.size; } }
    
       public void Clear() 
       {
           root = null;
           this.size = 0;
       }

       public void PreOrderTraverse() { PreOrderTraverse(root); }

       public void PreOrderTraverse(Node node) 
       {
           if (node != null) 
           {
               Console.WriteLine(node.Key);
               PreOrderTraverse(node.Left);
               PreOrderTraverse(node.Right);
           }
       }

       public void IterativePreOrder() { IterativePreOrder(root); }

       public void IterativePreOrder(Node node) 
       {
           Stack<Node> stack = new Stack<Node>();
           stack.Push(node);
           while(stack.Count > 0)
           {
               if (node != null)
               {
                   Console.WriteLine(node.Key);
                   if (node.Right != null)
                   {
                       stack.Push(node.Right);
                   }
                   node = node.Left;
               }
               else { node = stack.Pop(); }
           }
       }

       public void InOrderTraverse(Node node) 
       {
           if (node != null) 
           {
               InOrderTraverse(node.Left);
               Console.WriteLine(node.Key);
               InOrderTraverse(node.Right);
           }
       }

       public void PostOrderTraverse(Node node)
       {
           if (node != null)
           {
               InOrderTraverse(node.Left);
               InOrderTraverse(node.Right);            
               Console.WriteLine(node.Key);
           }
       }

       public void LevelOrderQueque() 
       {
           Queue<Node> queque = new Queue<Node>();
           queque.Enqueue(root);
           while(queque.Count > 0)
           {
               Node node = queque.Dequeue();
               if (node.Left != null) { queque.Enqueue(node.Left);  }
               if (node.Right != null) { queque.Enqueue(node.Right);  }
           }
       }

       public void LevelOrderStack()
       {
           Stack<Node> stack = new Stack<Node>();
           stack.Push(root);
           while (stack.Count > 0)
           {
               Node node = stack.Pop();
               if (node.Left != null) { stack.Push(node.Left);  }
               if (node.Right != null) { stack.Push(node.Right); }
           }
       }
    }
}
