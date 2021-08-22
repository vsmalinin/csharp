using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            string s;
            string[] str;
            double det = 1;
            //определяем переменную EPS
            const double EPS = 1E-9;
            //размерность матрицы
            int n;
            //вводим n
            Console.WriteLine("Enter the dimension of the matrix");
            n = int.Parse(Console.ReadLine());
            //определяем массив размером nxn
            double[][] a = new double[n][];
            double[][] b = new double[1][];
            b[0] = new double[n];
            //заполняем его
            Console.WriteLine("Enter the n rows of n elements");
            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine();
                str = s.Split(' ');
                a[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = double.Parse(str[j]);
                }
            }
            //проходим по строкам
            for (int i = 0; i < n; ++i)
            {
                //присваиваем k номер строки
                int k = i;
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < n; ++j)
                    //проверяем
                    if (Math.Abs(a[j][i]) > Math.Abs(a[k][i]))
                        //если равенство выполняется то k присваиваем j
                        k = j;
                //если равенство выполняется то определитель приравниваем 0 и выходим из программы
                if (Math.Abs(a[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }
                //меняем местами a[i] и a[k]
                b[0] = a[i];
                a[i] = a[k];
                a[k] = b[0];
                //если i не равно k
                if (i != k)
                    //то меняем знак определителя
                    det = -det;
                //умножаем det на элемент a[i][i]
                det *= a[i][i];
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < n; ++j)
                    //каждый элемент делим на a[i][i]
                    a[i][j] /= a[i][i];
                //идем по столбцам
                for (int j = 0; j < n; ++j)
                    //проверяем
                    if ((j != i) && (Math.Abs(a[j][i]) > EPS))
                        //если да, то идем по k от i+1
                        for (k = i + 1; k < n; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
            }
            //выводим результат
            Console.WriteLine(det);
            Console.ReadLine();
        }
    }
}