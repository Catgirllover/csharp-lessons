// See https://ausing System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nominalVal;
            int nominalSum = 0;
            Console.WriteLine("Сколько у вас карт?");
            string cardSum = Console.ReadLine();
            for (int i = 1; i <= int.Parse(cardSum); i++)
            {
                Console.WriteLine($"Введите номинал {i} карты");
                nominalVal = Console.ReadLine();
                switch (nominalVal)
                {
                    case "1":
                        nominalSum += 1;
                        break;
                    case "2":
                        nominalSum += 2;
                        break;
                    case "3":
                        nominalSum += 3;
                        break;
                    case "4":
                        nominalSum += 4;
                        break;
                    case "5":
                        nominalSum += 5;
                        break;
                    case "6":
                        nominalSum += 6;
                        break;
                    case "7":
                        nominalSum += 7;
                        break;
                    case "8":
                        nominalSum += 8;
                        break;
                    case "9":
                        nominalSum += 9;
                        break;
                    case "10":
                        nominalSum += 10;
                        break;
                    case "J":
                        nominalSum += 11;
                        break;
                    case "Q":
                        nominalSum += 12;
                        break;
                    case "K":
                        nominalSum += 13;
                        break;
                    case "T":
                        nominalSum += 14;
                        break;
                }
            }
            Console.WriteLine(nominalSum);
        }
    }
}