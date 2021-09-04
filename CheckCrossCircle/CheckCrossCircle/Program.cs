﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CheckCrossCircle
{
    class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
            Console.ReadKey();

        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }


        public static bool testStrok(Mark[,] field, Mark mark)
        {
            bool winner = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                var a = 0;
                for (int j = 0; j < field.GetLength(1); j++)
                    if (mark == field[i, j])
                    {
                        a = a + 1;
                        if (a == 3)
                        {
                            winner = true;
                            break;
                        }
                    }
            }
            return winner;
        }

        public static bool testColon(Mark[,] field, Mark mark)
        {
            bool winner = false;
            for (int nomerStroki = 0; nomerStroki < field.GetLength(0); nomerStroki++)
            {
                var a = 0;
                for (int nomerKolonki = 0; nomerKolonki < field.GetLength(1); nomerKolonki++)
                    if (mark == field[nomerKolonki, nomerStroki])
                    {
                        a = a + 1;
                        if (a == 3)
                        {
                            winner = true;
                            break;
                        }
                    }
            }
            return winner;
        }

        public static bool testDiagonal(Mark[,] field, Mark mark)
        {
            if ((mark == field[0, 0] && mark == field[1, 1] && mark == field[2, 2]) || (mark == field[2, 0] && mark == field[1, 1] && mark == field[0, 2]))
                return true;
            else return false;
        }

        public static bool testWin(Mark[,] field, Mark mark)
        {
            bool diagonal = testDiagonal(field, mark);
            bool stroka = testStrok(field, mark);
            bool kolonka = testColon(field, mark);
            return (diagonal || stroka || kolonka);
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            bool circleWin = testWin(field, Mark.Circle);
            bool crossWin = testWin(field, Mark.Cross);

            if (circleWin == crossWin) return GameResult.Draw;

            return circleWin ? GameResult.CircleWin : GameResult.CrossWin;
        }
    }
}