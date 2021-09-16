using System;
using System.Collections.Generic;
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
    }
}
