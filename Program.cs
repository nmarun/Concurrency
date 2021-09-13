using Concurrency.Chapter01Overview;
using System;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await Chapter01.DoSomethingAsync();
        }

    }
}
