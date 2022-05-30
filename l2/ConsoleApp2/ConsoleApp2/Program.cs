// Seusing System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            float ictmark = 5f;
            float mathmark = 4.6f;
            float physicsmark = 4.1f;
            float marksum = ictmark + mathmark + physicsmark;
            float mark = marksum / 3;
            Console.WriteLine("Средняя отметка: " + mark);
            Console.ReadKey();
        }
    }
}