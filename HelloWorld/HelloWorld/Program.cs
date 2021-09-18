using System;

namespace HelloWorld
{
    class Program
    {
        public static int Main(string[] args)
        {
            
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;
            if (args.Length == 1)
            {
                int N = Int32.Parse(args[0]);
                double sum = 0;
                for (int i =1; i <= N; i++)
                {
                    sum += i;
                }
                Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}! Сумма чисел аргумента равна {sum}.");
                return 0;
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}! Некорректный аргумент, не могу вычислить сумму.");
                return 1;
            }
        }
    }
}
