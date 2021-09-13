using System;
using System.Threading.Tasks;

namespace Concurrency.Chapter01Overview
{
    public class Chapter01
    {
        public static async Task DoSomethingAsync()
        {
            int val = 13;
            // Asynchronously wait 1 second.
            //await Task.Delay(TimeSpan.FromSeconds(1));
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            val *= 2;
            // Asynchronously wait 1 second.
            //await Task.Delay(TimeSpan.FromSeconds(1));
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            Console.WriteLine(val);
        }
    }
}
