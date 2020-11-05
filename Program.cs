using System;
using System.Globalization;

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



            //получение значений Х
            arrX = GetX(begin,end, step);

            //получения значений Y
            arrY = GetY(arrX);

            //вывод таблицы
            ShowTable(arrX, arrY);


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

        //начальное значение диапазона не может быть больше конечного

        //получение значений Х
        static double[] GetX(double begin, double end, double step)
        {
            double[] arrX = new double[] { };
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
        static void ShowTable(double[] X, double[] Y, int size)
        {
            int xml = GetMaxVarLength(X, size);
            int yml = GetMaxVarLength(Y, size);

            
            Console.WriteLine('|'+CreateStr(xml)+'|'+CreateStr(yml)+'|');
            Console.WriteLine('|' + CreateStr("X",xml) + '|' + CreateStr("Y",yml) + '|');
            Console.WriteLine('|' + CreateStr(xml) + '|' + CreateStr(yml) + '|');
            for (int i=0;i<size;i++)
            {
                Console.WriteLine('|' + CreateStr(X[i],xml) + '|' + CreateStr(Y[i],yml) + '|');
            }
            Console.WriteLine('|' + CreateStr(xml) + '|' + CreateStr(yml) + '|');
        }
        //наполнение таблицы
        static string CreateStr(double num,int max_length)  //для чисел
        {
            num = Math.Round(num, 3);
            string num_str = Convert.ToString(num);
            int middle = num_str.Length;
            int start=(max_length-middle)/2;
            int end = max_length - start - middle;

            string s = new string(' ', start);
            string e = new string(' ', end);

            return (s + num_str + e);
        }
        static string CreateStr(string str, int max_length) //для строк
        {
            //string num_str = Convert.ToString(num);
            int middle = str.Length;
            int start = (max_length - middle) / 2;
            int end = max_length - start - middle;

            string s = new string(' ', start);
            string e = new string(' ', end);

            return (s + str + e);
        }
        static string CreateStr(int N)  //для разделительных линий
        {
            string floor = new string('-', N);
            return floor;
        }
    }
}
