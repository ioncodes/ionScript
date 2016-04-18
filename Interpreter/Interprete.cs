using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker;

namespace Interpreter
{
    public class Interprete
    {
        public static List<string> stringVars = new List<string>(); //values string
        public static List<double> doubleVars = new List<double>(); //values floats
        public static List<string> nameVars = new List<string>(); //name of vars

        public static void Decide(string code)
        {
            //Tasks: Analyze codeline, take decision
            if(code != "")
            {
                if(code.Substring(0,3) == "out") //out = write text to console
                {
                    //write command found
                    string args = code.Remove(0, 3); //remove "out" for easier work in future
                    if(args.Substring(0, 1) == " ") //everything ok, no syntax error
                    {
                        args = args.Remove(0, 1);
                        if (args.Substring(0, 1) == "\"") //string following
                        {
                            string text = args.Split('\"', '\"')[1];
                            Work.Write(text);
                        }
                        else //variable following
                        {
                            string varname = args;
                            int index = nameVars.FindIndex(a => a == "s" + varname);
                            if (index == -1)
                            {
                                index = nameVars.FindIndex(a => a == "d" + varname);
                                if (index == -1)
                                {
                                    Console.WriteLine(Errors.VarNotFound);
                                }
                                else
                                {
                                    if (index == 0) //bugfix
                                    {
                                        Work.Write(doubleVars[index].ToString());
                                    }
                                    else
                                    {
                                        Work.Write(doubleVars[index-1].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (index == 1) //bugfix
                                {
                                    Work.Write(stringVars[index]);
                                }
                                else
                                {
                                    Work.Write(stringVars[index-1]);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(Errors.SpaceMissing); //space missing
                    }
                }
                if (code.Substring(0, 2) == "in") //in = Get text from input
                {
                    //in command found
                    string args = code.Remove(0, 2); //remove "in" for easier work in future
                    if (args.Substring(0, 1) == " ") //everything ok, no syntax error
                    {
                        args = args.Remove(0, 1);
                        string varname = args;
                        int index = nameVars.FindIndex(a => a == "s" + varname);
                        if(index == -1)
                        {
                            index = nameVars.FindIndex(a => a == "d" + varname);
                            if(index == -1)
                            {
                                Console.WriteLine(Errors.VarNotFound);
                            }
                            else
                            {
                                string input = Work.Read();
                                double convInput = Convert.ToDouble(input);
                                doubleVars[index-1] = convInput;
                            }
                        }
                        else
                        {
                            stringVars[index-1] = Work.Read();
                        }
                    }
                    else
                    {
                        Console.WriteLine(Errors.SpaceMissing); //space missing
                    }
                }
                else if(code.Substring(0, 3) == "set") //set = set variable, with value. autochoice of double or string
                {
                    //set command found
                    string args = code.Remove(0, 3); //remove "set" for easier work in future
                    if (args.Substring(0, 1) == " ") //everything ok, no syntax error
                    {
                        args = args.Remove(0, 1);
                        if (args.Contains(" ")) //value
                        {
                            string name = args.Split(' ')[0]; //get var name
                            string value = args.Split(' ')[1]; //get value
                            double n;
                            if(double.TryParse(value, out n))
                            {
                                nameVars.Add("d" + name);
                                doubleVars.Add(Convert.ToDouble(value));
                                stringVars.Add(""); //filler
                            }
                            else
                            {
                                try
                                {
                                    nameVars.Add("s" + name);
                                    stringVars.Add(value);
                                    doubleVars.Add(0.0); //filler
                                }
                                catch
                                {
                                    Console.WriteLine(Errors.VariableConversion);
                                }
                            }   
                        }
                        else
                        {
                            Console.WriteLine(Errors.VariableNoValue);
                        }
                            
                    }
                    else
                    {
                        Console.WriteLine(Errors.SpaceMissing); //space missing
                    }
                }
                else if(code.Substring(0, 4) == "sset") //sset = variable type string, no value
                {
                    //sset command found
                    string args = code.Remove(0, 4); //remove "sset" for easier work in future
                    if (args.Substring(0, 1) == " ") //everything ok, no syntax error
                    {
                        args = args.Remove(0, 1); //remove blank
                        string name = args;
                        nameVars.Add("s" + name); //add name
                        stringVars.Add(""); //add blank item cause no value specified in script
                    }
                }
                else if (code.Substring(0, 4) == "dset") //dset = variable type double, no value
                {
                    //dset command found
                    string args = code.Remove(0, 4); //remove "dset" for easier work in future
                    if (args.Substring(0, 1) == " ") //everything ok, no syntax error
                    {
                        args = args.Remove(0, 1); //remove blank
                        string name = args;
                        nameVars.Add("d" + name); //add name
                        doubleVars.Add(0.0); //add blank item cause no value specified in script
                    }
                }
            }
        }
    }
}
