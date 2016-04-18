using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Interpreter;

namespace Core
{
    public class Start
    {        
        public static void Init(string path)
        {
            //Tasks: Prepare code, read file, take decisions
            string[] lines = File.ReadAllLines(path); //read script
            foreach(string line in lines)
            {
                line.Trim();
                Interprete.Decide(line);
            }
        }
    }
}
