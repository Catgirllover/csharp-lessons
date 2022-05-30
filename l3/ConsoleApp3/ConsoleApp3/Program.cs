using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            var value = Console.ReadLine();
            int intValue = int.Parse(value);
            int i = 2;
            bool simpleCheck = true;
            while (i < intValue && simpleCheck == true)
            {
                if (intValue % i == 0)
                {
                    simpleCheck = false;
                }
                i++;
            }
            if (simpleCheck == true)
                Console.WriteLine("Ваше число простое");
            if (simpleCheck == false)
                Console.WriteLine("Ваше число не является простым");
        }
    }
}