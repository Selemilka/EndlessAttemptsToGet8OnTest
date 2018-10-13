using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessAttemptsToGet8OnTest
{
    class Program
    {
        /// <summary>
        ///     Минимальный и максимальный размер массива (допустимый ввод)
        /// </summary>
        const int MinCorrectValue = 1, MaxCorrectValue = 1000000;

        /// <summary>
        ///     Метод, считвыающий целое число
        /// </summary>
        /// <param name="message">Сообщение, выводящееся на экран перед вводом</param>
        /// <returns>Считанное число</returns>
        public static int ReadInt(string message)
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) &&
                    (result >= MinCorrectValue && result <= MaxCorrectValue))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат ввода!!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Метод, создающий массив размера n, содержащий ряд -1, 1/3, -1/5, 1/7...
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <returns>Созданный массив</returns>
        public static double[] CreateArray(int n)
        {
            double[] array = new double[n];
            double denominator = -1;
            for (int i = 0; i < n; ++i)
            {
                array[i] = 1d / denominator;
                denominator = (Math.Abs(denominator) + 2) * (-Math.Sign(denominator));
            }
            return array;
        }
        
        /// <summary>
        ///     Метод, выводящий массив на экран по 8 элементов на строке, 4 знака после запятой
        /// </summary>
        /// <param name="array">Массив, который надо вывести</param>
        public static void ShowArray(double[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write($"{array[i]:F4} ");
                if (i % 8 == 7) //В строке уже выведено 8 элементов
                    Console.WriteLine();
            }
            if (array.Length % 8 != 0) //переход на новую строку по окончании вывода
                Console.WriteLine();
        }

        /// <summary>
        ///     Метод, удаляющий все отрицательные числа в массиве
        /// </summary>
        /// <param name="array">Массив,</param>
        public static void ShiftArray(ref double[] array)
        {
            double[] resultArray = new double[array.Length];
            int index = 0;

            foreach (double x in array)
                if (x >= 0)
                    resultArray[index++] = x;

            Array.Resize(ref resultArray, index);
            array = resultArray;
            /* 
             * Если не использовать метод Array.Resize:
            int[] array = new int[index];
            for (int i = 0; i < index; ++i)
                array[i] = resultArray[i];
             * Хотя можно заранее посчитать размер массива, но это будет выглядеть непонятно
            */

        }

        static void Main(string[] args)
        {
            do
            {
                int k = ReadInt("Введите k (размер массива): ");
                double[] a = CreateArray(k);
                Console.WriteLine("Исходный массив: ");
                ShowArray(a);
                ShiftArray(ref a);
                Console.WriteLine("Полученный массив: ");
                ShowArray(a);

                Console.WriteLine("Для завершения программы нажмите Escape");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
