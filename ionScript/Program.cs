using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.IO;

namespace ionScript
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            Console.Title = "ionScript v0.0.1a by ion - " + Path.GetFileName(path); //set title + filename
            Start.Init(path); //Send path to Core, to take decisions.
            Console.Read();
        }
    }
}
