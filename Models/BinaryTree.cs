using System;

namespace Concurrency.Models
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }
        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(Root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(Node root)
        {
            if (root == null) return;

            //Console.Write(root.Data + " ");
            Console.WriteLine(root.Data + " " + root.Left?.Data + " " + root.Right?.Data );
            DisplayTree(root.Left);
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            DisplayTree(Root);
        }

    }
}
