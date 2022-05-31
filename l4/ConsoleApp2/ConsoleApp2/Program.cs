using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int minValue = int.MaxValue;
            Console.WriteLine("Введите длину последовательности");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < minValue)
                    minValue = arr[i];
            }
            Console.WriteLine(minValue);
            Console.ReadKey();
        }
    }
}