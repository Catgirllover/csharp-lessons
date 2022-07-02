using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            FileEdit fileEdit = new FileEdit();
            FileView fileView = new FileView();
            bool waitingForResponse = true;


            while (waitingForResponse == true)
            {
                Console.WriteLine("RobCo Industries");
                Console.WriteLine("\nПеречень данных о сотрудниках.");


                if (File.Exists(@"info.txt") == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Файл содержащий данные о сотрудниках не существует.");
                    Console.WriteLine("Создать файл? (Y/n)");
                    string anwser = Console.ReadLine();
                    if (anwser.ToLower().Trim() == "y")
                        File.Create("info.txt").Close();
                    else
                        break;
                    Console.Clear();
                    Console.WriteLine("RobCo Industries");
                    Console.WriteLine("\nПеречень данных о сотрудниках.");
                }


                Console.WriteLine("Если вы хотите получить информацию о сотрудниках, введите read.");
                Console.WriteLine("Если вы хотите отредактировать информацию о новом сотруднике, введите edit.");
                Console.WriteLine("Если вы хотите закончить сессию данной программы, введите quit.");

                string response = Console.ReadLine();
                response.ToLower().Trim();

                if (response == "read")
                    fileView.Read();


                else if (response == "edit")
                    fileEdit.Edit();


                else if (response == "quit")
                    waitingForResponse = false;

                Console.Clear();
            }
        }
    }
}