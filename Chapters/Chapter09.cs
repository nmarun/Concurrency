using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Chapters
{
    public class Chapter09 
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private readonly HttpClient httpClient = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        static readonly IEnumerable<string> urlList = new string[]
        {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/gaming",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/xamarin"
        };

        public async Task CancellableTasks()
        {
            Console.WriteLine("Application started.");
            Console.WriteLine("Press the ENTER key to cancel...\n");

            Task cancelTask = Task.Run(() =>
            {
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("Press the ENTER key to cancel...");
                }

                Console.WriteLine("\nENTER key pressed: cancelling downloads.\n");
                cancellationTokenSource.Cancel();
            });

            Task sumPageSizesTask = SumPageSizesAsync();

            await Task.WhenAny(new[] { cancelTask, sumPageSizesTask });

            Console.WriteLine("Application ending.");
        }

        private async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            try
            {
                foreach (string url in urlList)
                {
                    int contentLength = await ProcessUrlAsync(url, httpClient, cancellationTokenSource.Token);
                    total += contentLength;
                }
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine(oce.Message);
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }

        private async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            if (token.IsCancellationRequested) 
            {
                throw new TaskCanceledException();
            }
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }
    }
}
