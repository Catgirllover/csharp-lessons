using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Введите диапазон");
            int length = int.Parse(Console.ReadLine());
            int randNum = rnd.Next(0, length);
            string guessNum;
            Console.WriteLine("Угадывайте число от 0 до заданного вами диапазона");
            do
            {
                guessNum = Console.ReadLine();
                if (guessNum == "")
                {
                    Console.WriteLine($"Загаданное число: {randNum}");
                    break;
                }
            } while (int.Parse(guessNum) != randNum);
            if (int.Parse(guessNum) == randNum)
                Console.WriteLine("Вы угадали загаданное число");
        }
    }
}