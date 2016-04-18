using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Errors
    {
        public const string UnexpetedSpace = "Syntax Error! Unexpeted Space!";
        public const string SpaceMissing = "Syntax Error! Space Missing!";
        public const string VariableConversion = "Couldn't set variable!";
        public const string VariableNoValue = "Variable has no value!";
        public const string VarNotFound = "Variable not found!";
    }
}
