using Concurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Chapters
{
    public class Chapter03
    {
        public void StoppingParallelForEach(List<int> ints)
        {
            Parallel.ForEach(ints, (item, state) =>
            {
                if (item > 13)
                {
                    Console.WriteLine("stopping");
                    state.Stop();
                }
                else
                {
                    item *= 2;
                    Console.WriteLine(item);
                }
            });
        }

        public void ProcessTree(Node root)
        {
            var task = Task.Factory.StartNew(() => Traverse(root),
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default);

            task.Wait();
        }

        private void Traverse(Node current)
        {
            DoExpensiveActionOnNode(current);
            if (current.Left != null)
            {
                Task.Factory.StartNew(() => Traverse(current.Left),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent, // attaches to parent task, runs synchronously
                TaskScheduler.Default);
            }
            if (current.Right != null)
            {
                Task.Factory.StartNew(() => Traverse(current.Right),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent, // change this to DenyChildAttach, right nodes run independently of the parent
                TaskScheduler.Default);
            }
        }

        private void DoExpensiveActionOnNode(Node current)
        {
            Console.WriteLine("processing node: " + current.Data);
        }

        public BinaryTree PopulateTree()
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(4);
            binaryTree.Insert(2);
            binaryTree.Insert(8);
            binaryTree.Insert(11);
            binaryTree.Insert(5);
            binaryTree.Insert(1);
            binaryTree.Insert(3);

            binaryTree.DisplayTree();

            return binaryTree;
        }

        // both these methods produced the same output
        // the output was ordered in both
        public List<int> MultiplyBy2(List<int> values)
        {
            return values.AsParallel().Select(item => item * 2).ToList();
        }
        public List<int> OrderedMultiplyBy2(List<int> values)
        {
            return values.AsParallel().AsOrdered().Select(item => item * 2).ToList();
        }
    }
}
