using Concurrency.Chapters;
using Concurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Chapter03 chapter03 = new Chapter03();
            //List<int> ints = new List<int> { 1, 2, 3, 4, 8, 21, 7, 15, 13, 7, 9 };

            ////chapter03.StoppingParallelForEach(ints);

            ////BinaryTree binaryTree = chapter03.PopulateTree();
            ////chapter03.ProcessTree(binaryTree.Root);

            //List<int> output = chapter03.MultiplyBy2(ints);
            //output.ForEach(item => Console.Write(item + " "));

            //Console.WriteLine();

            //output = chapter03.OrderedMultiplyBy2(ints);
            //output.ForEach(item => Console.Write(item + " "));
            //Console.WriteLine();

            //Chapter09 chapter09 = new Chapter09();
            //await chapter09.CancellableTasks();
            //await chapter09.CancellOtherTaskwhenOneIsDone();

            Chapter13 chapter13 = new Chapter13();
            Console.WriteLine(chapter13.UseSharedInteger());
            Console.WriteLine(chapter13.UseSharedInteger());
            Console.WriteLine(chapter13.UseSharedInteger());
            Console.WriteLine(chapter13.UseSharedInteger());

            Console.WriteLine("Done");
        }
    }
}
