using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class RPN
    {
        static public object[] ParseExpression(string expressions)
        {
            List<object> list1 = ParseText(expressions);

            Stack<object> opz = new Stack<object>();
            Stack<char> stek = new Stack<char>();

            foreach (object element in list1)
            {
                if (Information.IsNumeric(element)) opz.Push(element);
                if (element.Equals('(')) stek.Push(Convert.ToChar(element));
                else if (stek.Count != 0 && element.Equals(')'))
                {
                    while (stek.Count != 0 && stek.Peek() != '(')
                    {
                        if (stek.Peek() != '(') opz.Push(stek.Pop());
                    }
                    if (stek.Count != 0 && stek.Peek() == '(') stek.Pop();
                }
                else if (element.Equals('+') || element.Equals('*') ||
                   element.Equals('-') || element.Equals('/') ||
                   element.Equals('^'))
                {
                    if (stek.Count != 0 && stek.Peek() != '(' && (GetPriority(stek.Peek()) >= GetPriority(Convert.ToChar(element)))) opz.Push(stek.Pop());
                    stek.Push(Convert.ToChar(element));
                }
            }
            while (stek.Count != 0)
            {
                opz.Push(stek.Pop());
            }
            object[] rpnArray = new object[opz.Count];
            for (int i = rpnArray.Length - 1; i >= 0; i--)
                rpnArray[i] = opz.Pop();
            return rpnArray;
        }
        static public List<object> ParseText(string str)
        {
            List<object> list = new List<object>();

            for (int i = 0; i < str.Length; i++)
            {
                string element = "";
                if (char.IsDigit(str[i]))
                {
                    while (i<=str.Length-1 && (char.IsDigit(str[i]) || str[i].Equals(',') || str[i].Equals('.')))
                    {
                        element += str[i];
                        i++;
                    }
                }
                double num;
                if (!element.Equals("") &&
                    double.TryParse(element, System.Globalization.NumberStyles.AllowDecimalPoint,
                    System.Globalization.CultureInfo.InvariantCulture, out num)) list.Add(num);
                else if (str[i].Equals('+') || str[i].Equals('*') ||
                   str[i].Equals('-') || str[i].Equals('/') ||
                   str[i].Equals('(') || str[i].Equals(')') ||
                   str[i].Equals('^') || str[i].Equals('X'))
                {
                    list.Add(str[i]);
                }

            }
            return list;
        }
        static int GetPriority(char operation)
        {
            int priority = 0;
            if (operation.Equals('^')) priority = 3;
            else if (operation.Equals('*') || operation.Equals('/')) priority = 2;
            else priority = 1;
            return priority;
        }
    }
}
