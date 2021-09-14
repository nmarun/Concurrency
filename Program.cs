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

            Chapter02 chapter02 = new Chapter02();
            int length = await chapter02.FirstRespondingUrlAsync("http://google.com", "http://timesofindia.com");
            Console.WriteLine("length = {0}", length);

            chapter02 = new Chapter02();
            length = await chapter02.FirstRespondingUrlAsync("http://google.com", "http://timesofindia.com");
            Console.WriteLine("length = {0}", length);

            chapter02 = new Chapter02();
            length = await chapter02.FirstRespondingUrlAsync("http://google.com", "http://timesofindia.com");
            Console.WriteLine("length = {0}", length);

            chapter02 = new Chapter02();
            length = await chapter02.FirstRespondingUrlAsync("http://google.com", "http://timesofindia.com");
            Console.WriteLine("length = {0}", length);



        }
    }
}
