using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double begin = 1.1, end = 11.4;
            int size;
            double step = 1.11;
            double[] Y,X;


            //функция y=x^2+2x-3
            Console.WriteLine("Функция y=x^2+2x-3");
            //ввод значений
            GetInput(ref begin, ref end, ref step);

            //получение кол-ва значений Х
            size = GetSize(begin, end, step);

            //получение значений Х
            X = GetX(begin, size, step);

            //получения значений Y
            Y = GetY(X, size);

            //вывод таблицы
            ShowTable(X, Y, size);


        }

        //метод ввода
        static void GetVar(ref double B)
        {
            string A;
            do
            {
                A = Console.ReadLine();
                A = A.Replace('.', ',');            //проверка на точку
            } while (!double.TryParse(A, out B));
        }
        //получение кол-ва значений функции
        static int GetSize(double begin, double end,double step)
        {
            int size = 0;
            while(begin <= end)
            {
                begin += step;
                size++;
            }
            return size;
        }

        //начальное значение диапазона не может быть больше конечного
        static void GetInput(ref double begin, ref double end, ref double step)
        {
            do
            {
                //ввод x0
                Console.WriteLine("Введите минимальное значение Х:");
                GetVar(ref begin);
                //ввод х
                Console.WriteLine("Введите максимальное значение Х:");
                GetVar(ref end);
                //ввод шага построения
                Console.WriteLine("Введите шаг построения Х:");
                GetVar(ref step);
            } while (begin > end);
        }

        //получение значений Х
        static double[] GetX(double begin,int size, double step)
        {
            double[] X = new double[size];
            for(int i=0;i<size;i++)
            {
                X[i] = begin;
                begin += step;
            }
            return X;

        }

        //метод получения Y
        static double[] GetY(double[] X,int size)
        {
            double[]  Y= new double[size];
            for(int i=0;i<size;i++)
            {
                Y[i] = X[i]*X[i]+2*X[i]-3;
            }
            return Y;
        }

        //длина самого длинного элемента
        static int GetMaxVarLength(double[] Array, int size)
        {
            int MaxVarLength=0;
            for (int i = 0; i < size; i++)
            {
                Array[i] = Math.Round(Array[i], 3);
                string L = Convert.ToString(Array[i]);
                if (L.Length > MaxVarLength) MaxVarLength = L.Length;
            }
            return MaxVarLength;
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
