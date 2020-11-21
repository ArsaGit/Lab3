using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = InputOutput.ReadFromFile();
            Function func = new Function();
            func.GetInfo(data);
            object[] rpn = RPN.ParseExpression(func.function);
            foreach (object o in rpn)
                Console.WriteLine(o);
        }
    }
}
