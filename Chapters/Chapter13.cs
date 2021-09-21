using System;

namespace Concurrency.Chapters
{
    public class Chapter13
    {
        static int _simpleValue;
        static readonly Lazy<int> MySharedInteger = new Lazy<int>(() => _simpleValue++);
        public int UseSharedInteger()
        {
            return MySharedInteger.Value;
        }
    }
}
