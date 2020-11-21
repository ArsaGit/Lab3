using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Table
    {
        //получение значений Х
        static private double[] GetX(Function func)
        {
            int size = 0;
            for (double i = func.x0; i < func.x1; i += func.step)
                size++;
            double[] arrX = new double[size];
            int j = 0;
            for (double i = func.x0; i < func.x1; i += func.step)
            {
                arrX[j] = i;
                j++;
            }
            return arrX;
        }

        //метод получения Y / вычисление значений функции
        static private double[] GetY(double[] arrX,object[] rpn)
        {
            double[] arrY = new double[arrX.Length];
            for (int i = 0; i < arrX.Length; i++)
            {
                arrY[i] = RPN.Calculate(arrX[i],rpn);
            }
            return arrY;
        }

        //длина самого длинного элемента
        static private int GetMaxVarLength(double[] arr)
        {
            int maxVarLength = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Math.Round(arr[i], 3);
                string str = Convert.ToString(arr[i]);
                if (str.Length > maxVarLength) maxVarLength = str.Length;
            }
            return maxVarLength;
        }

        //метод вывода таблицы
        static public string CreateTable(Function func,object[] rpn)
        {
            string table = "";
            double[] X = GetX(func);
            double[] Y = GetY(X,rpn);
            int xml = GetMaxVarLength(X);
            int yml = GetMaxVarLength(Y);

            table += WriteBoxLine('┌', '─', '┬', '┐', xml, yml);
            table += WriteBoxLine('│', ' ', '│', '│', "X", "Y", xml, yml);
            table += WriteBoxLine('├', '─', '┼', '┤', xml, yml);
            for (int i = 0; i < X.Length; i++)
            {
                if (i == X.Length - 1) table += WriteBoxLine('└', '─', '┴', '┘', xml, yml);
                else table += WriteBoxLine('│', ' ', '│', '│', X[i].ToString(), Y[i].ToString(), xml, yml);
            }
            return table;
        }
        static string WriteBoxLine(char beginSym, char filler, char wallSym, char endSym, string x, string y, int xml, int yml)
        {
            string str = beginSym + CreateStr(x, xml, filler) + wallSym + CreateStr(y, yml, filler) + endSym + '\n';
            return str;
        }
        static string WriteBoxLine(char beginSym, char filler, char wallSym, char endSym, int xml, int yml)
        {
            string str = beginSym + CreateStr("", xml, filler) + wallSym + CreateStr("", yml, filler) + endSym + '\n';
            return str;
        }
        //наполнение таблицы
        static private string CreateStr(string str, int maxLength, char filler)
        {
            if (str.Length == maxLength) return str;
            else
            {
                string temp = new string(filler, maxLength - str.Length);
                str += temp;
                return str;
            }
        }
    }
}
