using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOneTinyAttempt
{
    class Program
    {
        public static int ReadInt(string message, int minCorrectValue, int maxCorrectValue)
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) &&
                    (result >= minCorrectValue && result <= maxCorrectValue))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат ввода!!");
            } while (!isCorrect);

            return result;
        }

        public static void SummCalculate(int n, out double s1, out double s2)
        {
            double[] r = new double[n + 1];
            r[0] = 1;
            for (int i = 1; i <= n; ++i)
            {
                double sum = 0;
                double fraction = i + 1; //Значение дроби при k = 0
                for (int k = 1; k <= i; ++k)
                {
                    fraction = fraction * Math.Max((i - k + 1), 1) / (k + 1);
                    sum += fraction * r[i - k];
                }
                r[i] = -1d / (i + 1) * sum;
                Console.WriteLine($"r[{i}] = {r[i]}");
            }
            s1 = 0;
            s2 = 0;
            for (int i = 0; i <= n; i += 2)
                s1 += r[i];
            for (int i = 1; i <= n; i += 2)
                s2 += r[i];
        }

        public static void Print(int a, double b, double c)
        {
            Console.WriteLine($"{a} {b:F3} {c:F3}");
        }

        static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите n: ", 2, 1000);
                for (int i = 1; i < n; ++i)
                {
                    SummCalculate(i, out double s1, out double s2);
                    Print(i, s1, s2);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
