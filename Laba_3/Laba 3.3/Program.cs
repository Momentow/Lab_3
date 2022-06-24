using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = 4;
            string[] A = { "AAC", "ABA", "CCCC", "CACC", "AAAAA", "BZAA", "BBBB"};

            var str = A.OrderBy(a => a).FirstOrDefault(st => st.Length == L);
            Console.WriteLine($"Answer: {str}");
        }
    }
}
