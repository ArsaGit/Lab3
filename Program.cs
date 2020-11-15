using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "x-2;1.a11;1.1;11.4";
            Function f= new Function();
            f.GetInfo(str);
            f.Print();
        }
    }
}
