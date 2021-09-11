using System;

namespace MyLib
{
    public class Time
    {
        private int hours;
        private int minutes;
        private static int counter = 0;

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value > 23 || value < 0)
                {
                    Console.WriteLine("Часы должны быть между 0 и 23.");
                }
                else
                {
                    hours = value;
                }
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value > 59 || value < 0)
                {
                    Console.WriteLine("Минуты должны быть между 0 и 59.");
                }
                else
                {
                    minutes = value;
                }
            }
        }

        public Time() : this(0, 0)
        {

        }
        public Time(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            counter++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Hours} часов {Minutes} минут.");
        }

        public static void DisplayCounter()
        {
            Console.WriteLine($"Создано {counter} объект(-ов) класса Time.");
        }

        public Time AddingMinutes(int m)
        {
            if (this.Minutes + m < 59)
            {
                this.Minutes += m;
            }
            else
            {
                this.Hours++;
                this.Minutes = this.Minutes + m - 60;
            }
            return this;
        }

    }
}
