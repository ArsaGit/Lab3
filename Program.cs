using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = InputOutput.ReadFromFile();
            Function funct = new Function();
            funct.GetInfo(data);
            List<object> list = RPN.ParseText(funct.function);
            foreach (object obj in list)
                Console.WriteLine(obj);
            Console.WriteLine();
            Stack<object> rpn = RPN.ParseExpression(funct.function);

            while (rpn.Count > 0) Console.WriteLine(rpn.Pop());

        }
    }
}
