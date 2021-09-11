using System;
using MyLib;

namespace PracticWork9
{
    class Program
    {
        static Time AddMinutes(Time t, int m)
        {
            if (t.Minutes + m < 59)
            {
                t.Minutes += m;
            }
            else
            {
                t.Hours++;
                t.Minutes = t.Minutes + m - 60;
            }
            return t;
        }

        static void Main(string[] args)
        {
            Time t1 = new();
            Console.Write("Введите количество часов: ");
            t1.Hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество минут: ");
            t1.Minutes = Convert.ToInt32(Console.ReadLine());
            t1.DisplayInfo();
            Console.WriteLine("Вызывая статическую функцию добавим 30 минут и получим:");
            AddMinutes(t1, 30);
            t1.DisplayInfo();
            Console.WriteLine("Вызывая метод класса добавим еще 40 минут и получим:");
            t1.AddingMinutes(40);
            t1.DisplayInfo();
            Time.DisplayCounter();

            Console.WriteLine("Создадим новый объект класса через другой конструктор:");
            Time t2 = new(12, 12);
            t2.DisplayInfo();
            Time.DisplayCounter();

            Console.ReadKey();
        }
    }
}
