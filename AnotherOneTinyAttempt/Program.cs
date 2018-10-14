using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOneTinyAttempt
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


        static void Main(string[] args)
        {
            do
            {

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
