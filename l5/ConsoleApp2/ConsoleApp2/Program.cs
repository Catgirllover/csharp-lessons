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


        public static void ReverseWords(string inputPhrase)
        {
            string dataHolder;
            string[] phraseArr = Splitter(inputPhrase);
            for (int i = 0; i < phraseArr.Length; i++)
            {
                if (phraseArr.Length % 2 == 0)
                {
                    if (i < phraseArr.Length / 2)
                    {
                        dataHolder = phraseArr[phraseArr.Length-1 - i];
                        phraseArr[phraseArr.Length-1 - i] = phraseArr[i];
                        phraseArr[i] = dataHolder;
                    }
                }
                else if (i < phraseArr.Length / 2)
                {
                    dataHolder = phraseArr[phraseArr.Length-1 - i];
                    phraseArr[phraseArr.Length-1 - i] = phraseArr[i];
                    phraseArr[i] = dataHolder;
                }
            }
            foreach (var i in phraseArr)
            {
                Console.Write($"{i} ");
            }
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            ReverseWords(text);
        }
    }
}