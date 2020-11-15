using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Function
    {
        public double x0;
        public double x1;
        public double step;
        public string function;

        public Function()
        {
            x0 = 0;
            x1 = 0;
            step = 0;
            function = "";
        }
        public Function(string expression,int step0,int rangeStart,int rangeEnd)
        {
            function = expression;
            step = step0;
            x0 = rangeStart;
            x1 = rangeEnd;
        }
        public void GetInfo(string data)
        {
            int check;
            do
            {
                check = 0;
                string[] strArr = data.Split(';', StringSplitOptions.RemoveEmptyEntries);
                function = strArr[0];
                if (!double.TryParse(strArr[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out step)) check++;
                if (!double.TryParse(strArr[2], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out x0)) check++;
                if (!double.TryParse(strArr[3], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out x1)) check++;
                if (check != 0)
                {
                    Console.WriteLine("Введены некорректные данные!");
                    Console.WriteLine("Введите функцию:");
                    string functionTemp = Console.ReadLine();
                    Console.WriteLine("Введите шаг:");
                    string stepTemp = Console.ReadLine();
                    Console.WriteLine("Введите начало диапазона:");
                    string x0Temp = Console.ReadLine();
                    Console.WriteLine("Введите конец диапазона:");
                    string x1Temp = Console.ReadLine();
                    InputOutput.WriteInFile($"{functionTemp};{stepTemp};{x0Temp};{x1Temp}", "input.txt");
                }
            } while (check!=0);
        }
        public void Print()
        {
            Console.WriteLine($"f(x)={function}");
            Console.WriteLine($"step={step}");
            Console.WriteLine($"Range x=[{x0};{x1}]");
        }

    }
}
