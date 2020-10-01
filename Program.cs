using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = 1, end = 11;
            int size = end - begin + 1;
            double step = 1.11;
            double[] Y;




            //ввод x0
            Console.WriteLine("Введите минимальное значение Х:");
            GetInput(ref begin);
            //ввод х
            Console.WriteLine("Введите максимальное значение Х:");
            GetInput(ref end);
            //ввод шага построения
            Console.WriteLine("Введите шаг построения Х:");
            GetInput(ref step);

            //получения значений Y
            Y = GetY(begin, size, step);

            //вывод таблицы
            ShowTable(begin, Y, size);


        }

        //метод ввода
        static void GetInput(ref int B)     //для int
        {
            string A;
            do
            {
                A = Console.ReadLine();
            } while (!int.TryParse(A, out B));
        }
        static void GetInput(ref double B)  //для double
        {
            string A;
            do
            {
                A = Console.ReadLine();
            } while (!double.TryParse(A, out B));
        }

        //метод получения Y
        static double[] GetY(int begin,int size,double step)
        {
            double[]  Y= new double[size];
            for(int i=0;i<size;i++)
            {
                Y[i] = step+begin;
                begin++;
            }
            return Y;
        }

        //длина самого длинного элемента
        static int GetMaxVarLength(int begin, int size)
        {
            int MaxVarLength=0;
            for (int i = 0; i < size; i++)
            {
                string L=Convert.ToString(begin);
                if (L.Length > MaxVarLength) MaxVarLength = L.Length;
                begin++;
            }
            return MaxVarLength;
        }
        static int GetMaxVarLength(double[] Y, int size)
        {
            int MaxVarLength = 0;
            for (int i = 0; i < size; i++)
            {
                Y[i] = Math.Round(Y[i], 3);
                string L = Convert.ToString(Y[i]);
                if (L.Length > MaxVarLength) MaxVarLength = L.Length;
            }
            return MaxVarLength;
        }


        static void ShowTable(int begin, double[] Y, int size)
        {
            int xml = GetMaxVarLength(begin, size);
            int yml = GetMaxVarLength(Y, size);

            
            Console.WriteLine('|'+CreateStr(xml)+'|'+CreateStr(yml)+'|');
            Console.WriteLine('|' + CreateStr("X",xml) + '|' + CreateStr("Y",yml) + '|');
            Console.WriteLine('|' + CreateStr(xml) + '|' + CreateStr(yml) + '|');
            for (int i=0;i<size;i++)
            {
                Console.WriteLine('|' + CreateStr(begin,xml) + '|' + CreateStr(Y[i],yml) + '|');
            }
            Console.WriteLine('|' + CreateStr(xml) + '|' + CreateStr(yml) + '|');
        }

        static string CreateStr(double num,int max_length)
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
        static string CreateStr(string str, int max_length)
        {
            //string num_str = Convert.ToString(num);
            int middle = str.Length;
            int start = (max_length - middle) / 2;
            int end = max_length - start - middle;

            string s = new string(' ', start);
            string e = new string(' ', end);

            return (s + str + e);
        }
        static string CreateStr(int N)
        {
            string floor = new string('-', N);
            return floor;
        }
    }
}
