using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true;
            string userCheck;
            Random rnd = new Random();
            while (programRunning == true)
            {
                Console.WriteLine("Чтобы начать выполнение программы, нажмите enter.");
                Console.WriteLine("Чтобы выйти, напишите exit");
                userCheck = Console.ReadLine();
                if (userCheck != "exit")
                {
                    Console.WriteLine("Введите кол-во столбцов в матрице");
                    string linesNum = Console.ReadLine();
                    Console.WriteLine("Введите кол-во строк в матрице");
                    string columnNum = Console.ReadLine();
                    int[,] arr2d = new int[int.Parse(linesNum), int.Parse(columnNum)];
                    int intLinesNum = int.Parse(linesNum);
                    int intColumnNum = int.Parse(columnNum);
                    int sum = 0;
                    for (int i = 0; i < intLinesNum; i++)
                    {
                        for (int j = 0; j < intColumnNum; j++)
                        {
                            arr2d[i, j] = rnd.Next(0, 256);
                            sum += arr2d[i, j];
                            string hexNum = arr2d[i, j].ToString("X");
                            if (arr2d[i, j] <= 15)
                                Console.Write($"0{hexNum} ");
                            else
                                Console.Write($"{hexNum} ");

                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine(sum);
                    Console.WriteLine(sum.ToString("X"));
                    Console.WriteLine();
                }
                else
                    programRunning = false;
            }
        }
    }
}