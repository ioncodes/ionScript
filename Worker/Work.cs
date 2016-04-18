using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    public class Work
    {
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }

        public static string Read()
        {
            return Console.ReadLine();
        }
    }
}
