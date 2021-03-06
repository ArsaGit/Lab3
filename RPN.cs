﻿using System;
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
                if (Information.IsNumeric(element) || element.Equals('X')) opz.Push(element);
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
            str = str.ToUpper();
            int i = 0;
            while(i < str.Length)
            {
                
                if (char.IsDigit(str[i]))
                {
                    string element = "";
                    while (i < str.Length && (char.IsDigit(str[i]) || str[i].Equals(',') || str[i].Equals('.')))
                    {
                        element += str[i];
                        i++;
                    }
                    double num;
                    if (!element.Equals("") &&
                        double.TryParse(element, System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.CultureInfo.InvariantCulture, out num)) list.Add(num);
                }
                else
                {
                    if(str[i]!=' ')list.Add(str[i]);
                    i++;
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
        static public double Calculate(double number, object[] rpn)
        {
            Stack<object> stack = new Stack<object>();
            for (int i = 0; i < rpn.Length; i++)
            {
                if (Information.IsNumeric(rpn[i])) stack.Push(rpn[i]);
                else if (rpn[i].Equals('X')) stack.Push(number);
                else
                {
                    double num2 = Convert.ToDouble(stack.Pop());
                    double num1 = Convert.ToDouble(stack.Pop());
                    switch (rpn[i])
                    {
                        case '+':
                            stack.Push(num1 + num2);
                            break;
                        case '-':
                            stack.Push(num1 - num2);
                            break;
                        case '*':
                            stack.Push(num1 * num2);
                            break;
                        case '/':
                            stack.Push(num1 / num2);
                            break;
                        case '^':
                            stack.Push(Math.Pow(num1, num2));
                            break;
                    }
                }
            }
            return Convert.ToDouble(stack.Pop());
        }
    }
}
