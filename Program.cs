using System;
using System.Globalization;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double begin = 1.1, end = 11.4;
            double step = 1.11;
            double[] arrY,arrX;


            //функция y=x^2+2x-3
            Console.WriteLine("Функция y=x^2+2x-3");

            //ввод x0
            Console.WriteLine("Введите минимальное значение Х:");
            begin=GetDouble();
            //ввод х
            Console.WriteLine("Введите максимальное значение Х:");
            end=GetDouble();
            //ввод шага построения
            Console.WriteLine("Введите шаг построения Х:");
            step=GetDouble();

            string input = ReadInput();

            //получение значений Х
            arrX = GetX(begin,end, step);

            //получения значений Y
            arrY = GetY(arrX);

            //вывод таблицы
            string table=CreateTable(arrX, arrY);
            Console.WriteLine(table);

            WriteOutput(table);
        }

        //метод ввода
        static double GetDouble()
        {
            while (true)
            {
                string str = Console.ReadLine();
                double num;
                if (double.TryParse(str,NumberStyles.AllowDecimalPoint,CultureInfo.InvariantCulture, out num)) return num;
            }
        }

        //получение значений Х
        static double[] GetX(double begin, double end, double step)
        {
            int size = 0;
            for (double i = begin; i < end; i += step)
                size++;
            double[] arrX = new double[size];
            int j = 0;
            for(double i=begin;i<end;i+=step)
            {
                arrX[j] = i;
                j++;
            }
            return arrX;
        }

        //метод получения Y / вычисление значений функции
        static double[] GetY(double[] arrX)
        {
            double[]  arrY= new double[arrX.Length];
            for(int i=0;i<arrX.Length;i++)
            {
                arrY[i] = arrX[i]*arrX[i]+2*arrX[i]-3;
            }
            return arrY;
        }

        //длина самого длинного элемента
        static int GetMaxVarLength(double[] arr)
        {
            int maxVarLength=0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Math.Round(arr[i], 3);
                string str = Convert.ToString(arr[i]);
                if (str.Length > maxVarLength) maxVarLength = str.Length;
            }
            return maxVarLength;
        }

        //метод вывода таблицы
        static string CreateTable(double[] X, double[] Y)
        {
            string table = "";
            int xml = GetMaxVarLength(X);
            int yml = GetMaxVarLength(Y);

            table += WriteBoxLine('┌', '─', '┬', '┐',xml, yml);
            table += WriteBoxLine('│', ' ', '│', '│', "X", "Y", xml, yml);
            table += WriteBoxLine('├', '─', '┼', '┤', xml, yml);
            for (int i = 0; i < X.Length; i++)
            {
                if (i == X.Length - 1) table += WriteBoxLine('└', '─', '┴', '┘',xml,yml);
                else table += WriteBoxLine('│', ' ', '│', '│', X[i].ToString(), Y[i].ToString(), xml, yml);
            }
            return table;
        }
        static string WriteBoxLine(char beginSym, char filler, char wallSym, char endSym, string x,string y, int xml,int yml)
        {
            string str = beginSym + CreateStr(x, xml, filler)+ wallSym+ CreateStr(y, yml, filler)+endSym+'\n';
            return str;
        }
        static string WriteBoxLine(char beginSym, char filler, char wallSym, char endSym, int xml, int yml)
        {
            string str = beginSym + CreateStr("", xml, filler) + wallSym + CreateStr("", yml, filler) + endSym + '\n';
            return str;
        }
        //наполнение таблицы
        static string CreateStr(string str,int maxLength,char filler)
        {
            if (str.Length == maxLength) return str;
            else
            {
                string temp = new string(filler, maxLength - str.Length);
                str += temp;
                return str;
            }
        }

        //input/output
        static string GetPath(string path = "input.txt")
        {
            string filePath = Environment.CurrentDirectory;
            filePath = @filePath.Substring(0, filePath.IndexOf("bin")) + path;
            return filePath;
        }
        static string ReadInput()
        {
            string path = GetPath();
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text=sr.ReadToEnd();
            }
            return text;
        }
        static void WriteOutput(string table)
        {
            string path = GetPath("output.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(table);
            }
        }
    }
}
