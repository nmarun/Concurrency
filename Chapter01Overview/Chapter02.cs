using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concurrency.Chapter01Overview
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
    }

   
}
