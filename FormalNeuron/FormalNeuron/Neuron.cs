using System;
using System.Linq;

class FormalNeuronDemo
{
    class Neuron
    {
        double a = 0.02;
        double b = -0.4;
        public double[] w = { 0, 0, 0, 0 }; //Веса
        public int c = 0; //Количество эпох обучения или полных проходов по выборке 

        public Neuron(int[][] X, int[] Y)
        {
            while (learn(X, Y))
            {
                if (c++ > 1000) break;
            }
        }

        public double calculate(int[] x)
        {
            double s = b;
            for (int i = 0; i < w.Length; i++)
                s += w[i] * x[i];
            return (s > 0) ? 1 : 0;
        }

        bool learn(int[][] X, int[] Y)
        {
            double[] w_ = new double[w.Length];
            Array.Copy(w, w_, w.Length);
            int i = 0;
            foreach (int[] x in X)
            {
                int y = Y[i++];
                for (int j = 0; j < x.Length; j++)
                {
                    w[j] += a * (y - calculate(x)) * x[j];
                }
            }
            return !Enumerable.SequenceEqual(w_, w);
        }
    }

    static int[][] X = // Обучающий вектор
    {
        new int[] {0,0,0,0},
        new int[] {0,0,0,1},
        new int[] {1,1,1,0}, // Ошибочные данные с результатом "нечетное"
        new int[] {1,1,1,0},
        new int[] {1,1,1,1}
    };

    static int[] Y = { 0, 1, 1, 0, 1 }; // Обучающий вектор для Х

    static int[][] Test = // Тестовые данные
    {
        new int[] {0,0,0,0},
        new int[] {0,0,0,1},
        new int[] {0,1,0,1},
        new int[] {0,1,1,0},
        new int[] {1,1,1,0},
        new int[] {1,1,1,1}
    };

    public static int Main()
    {
        Neuron neuron = new Neuron(X, Y);
        Console.WriteLine("[{0}] {1}", string.Join(",", neuron.w), neuron.c);
        foreach (int[] test in Test)
        {
            Console.WriteLine("[{0}] {1} {2}", string.Join(", ", test), test[3], neuron.calculate(test));
        }
        return 0;
    }
}
