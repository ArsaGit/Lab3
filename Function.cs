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
            bool IsInputCorrect = false;
            string[] strArr = data.Split(';', StringSplitOptions.RemoveEmptyEntries);
            function = strArr[0];
            IsInputCorrect = double.TryParse(strArr[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out step);
            IsInputCorrect = double.TryParse(strArr[2], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out x0);
            IsInputCorrect = double.TryParse(strArr[3], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out x1);
            //if(!IsInputCorrect)
        }
        public void Print()
        {
            Console.WriteLine($"f(x)={function}");
            Console.WriteLine($"step={step}");
            Console.WriteLine($"Range x=[{x0};{x1}]");
        }

    }
}
