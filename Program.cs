using Concurrency.Chapters;
using Concurrency.Models;
using System;
using System.Collections.Generic;

namespace Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Chapter03 chapter03 = new Chapter03();
            //List<int> ints = new List<int> { 1, 2, 3, 4, 8, 21, 7 };

            //chapter03.StoppingParallelForEach(ints);

            BinaryTree binaryTree = chapter03.PopulateTree();
            chapter03.ProcessTree(binaryTree.Root);

            Console.WriteLine("Done");
        }
    }
}
