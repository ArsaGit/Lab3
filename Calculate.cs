using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Calculate
    {
        //static public double Calculate(double number,Stack<object> rpn)
        //{
        //    Stack<object> signs = new Stack<object>();
        //    while (rpn.Count > 1)
        //    {
        //        while (IsSign(rpn.Peek())) signs.Push(rpn.Pop());
                
        //        if(rpn.Peek().Equals('X'))
        //    }

        //}
        static private bool IsSign(object obj)
        {
            char[] signs = { '+', '*', '-', '/', '^' };
            foreach (char ch in signs)
                if (obj.Equals(ch)) return true;
            return false;
        }
    }
}
