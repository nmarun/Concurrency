using Concurrency.Chapter01Overview;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hello World!");

            Chapter02 chapter02 = new Chapter02();
            await chapter02.ProcessTasksAsync();

            Console.WriteLine("Done");
        }
    }
}
