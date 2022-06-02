using System;

namespace ConsoleApp1
{
    class Program
    {
        public static string[] Splitter(string phrase)
        {
            string[] phraseArr = phrase.Split(' ');
            return phraseArr;
        }
        public static void Printer(string[] toPrint)
        {
            foreach (var printed in toPrint)
            {
                Console.WriteLine(printed);
            }
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] phraseArr = Splitter(text);
            Printer(phraseArr);
        }
    }
}