using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullname = "Иван Иванович Иванов";
            int age = 18;
            string email = "Ivan@mail.ru";
            float ictmark = 5f;
            float mathmark = 5f;
            float physicsmark = 5f;
            Console.WriteLine("ФИО: " + fullname);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("email: " + email);
            Console.WriteLine("Оценка по программированию: " + ictmark);
            Console.WriteLine("Оценка по математике: " + mathmark);
            Console.WriteLine("Оецнка по физике: " + physicsmark);
            Console.ReadKey();
        }
    }
}