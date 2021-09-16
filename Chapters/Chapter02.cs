using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concurrency.Chapters
{
    public class Chapter02
    {
        public async Task<int> FirstRespondingUrlAsync(string urlA, string urlB)
        {
            var httpClient = new HttpClient();
            // Start both downloads concurrently.
            Task<byte[]> downloadTaskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = httpClient.GetByteArrayAsync(urlB);
            // Wait for either of the tasks to complete.
            Task<byte[]> completedTask = await Task.WhenAny(downloadTaskA, downloadTaskB);
            // Return the length of the data retrieved from that URL.
            
            byte[] data = completedTask.Result;

            if(downloadTaskA.Id == completedTask.Id)
            {
                Console.WriteLine("completed task a");
            }
            if(downloadTaskB.Id == completedTask.Id)
            {
                Console.WriteLine("completed task b");
            }
            
            return data.Length;
        }

        static async Task<int> DelayAndReturnAsync(int val)
        {
            // output doesn't have any interaction with the main thread,
            // so doesn't need to continue on the captured context,
            // hence ConfigureAwait(false)
            await Task.Delay(TimeSpan.FromSeconds(val)).ConfigureAwait(false);
            return val;
        }
        // This method now prints "1", "2", and "3".
        public async Task ProcessTasksAsync()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync(2);
            Console.WriteLine("thread " + taskA.Id);
            Task<int> taskB = DelayAndReturnAsync(3);
            Console.WriteLine("thread " + taskB.Id);
            Task<int> taskC = DelayAndReturnAsync(1);
            Console.WriteLine("thread " + taskC.Id);
            var tasks = new[] { taskA, taskB, taskC };
            var processingTasks = tasks.Select(async t =>
            {
                Console.WriteLine("thread before " + t.Id);
                var result = await t;
                Console.WriteLine("thread after " + t.Id);
                Console.WriteLine(result);
            }).ToArray();
            
            // Await all processing to complete
            await Task.WhenAll(processingTasks);
        }
    }

   
}
