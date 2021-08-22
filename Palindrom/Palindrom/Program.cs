using System;

namespace Palindrom
{
    class Program
    {
        static bool IsPalindrom(string str)
        {
            if (str == null) throw new ArgumentNullException("str");
            str = str.ToLower().Replace(" ", string.Empty);
            return IsPalindromInternal(str);
        }


        static bool IsPalindromInternal(string str)
        {
            if (str.Length == 1 || string.IsNullOrEmpty(str)) return true;
            if (!str[0].Equals(str[str.Length - 1])) return false;
            return IsPalindromInternal(str.Substring(1, str.Length - 2));
        }

        static void Main(string[] args)
        {
            // А роза упала на лапу Азора
            // Лазер Боре хер обрезал

            Console.WriteLine("Input your text (program will check your text on palindrom):");
            var txt = Console.ReadLine();
            if (IsPalindrom(txt))
            {
                Console.WriteLine($"{Environment.NewLine}Your text '{txt}' IS palindrom!");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}Your text '{txt}' IS NOT palindrom!");
            }
            // Console.Write($"{Environment.NewLine}Press any key to exit...");
            // Console.ReadKey(true);
        }
    }
}
