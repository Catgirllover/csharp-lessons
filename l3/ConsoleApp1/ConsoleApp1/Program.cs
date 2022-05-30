using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runCheck = true;
            Console.WriteLine("Вводите числа или напишите exit если хотите выйти:");
            while (runCheck == true)
            {
                var userNum = Console.ReadLine();
                if (userNum == "exit")
                {
                    runCheck = false;
                }
                else if (int.Parse(userNum) % 2 == 0)
                {
                    Console.WriteLine("Число четное");
                }
                else
                {
                    Console.WriteLine("Число нечетное");
                }
            }
        }
    }
}