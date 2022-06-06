/*

Создайте справочник «Сотрудники».

Разработайте для предполагаемой компании программу, которая будет 
добавлять записи новых сотрудников в файл. Файл должен содержать следующие данные:

 * ID
 * Дату и время добавления записи
 * Ф. И. О.
 * Возраст
 * Рост
 * Дату рождения
 * Место рождения

Для этого необходим ввод данных с клавиатуры. После ввода данных:

 * eсли файла не существует, его необходимо создать;
 * eсли файл существует, то необходимо записать данные сотрудника в конец файла. 

При запуске программы должен быть выбор:

введём 1 — вывести данные на экран;
введём 2 — заполнить данные и добавить новую запись в конец файла.

Файл должен иметь следующую структуру:
  ---------------------------------------------------------------------------- 
/                                                                              \
|  1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва      |
|  2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск  |
|  …                                                                           |
\                                                                              /
  ---------------------------------------------------------------------------- 

Советы и рекомендации:
 * Обратите внимание, что в строке есть символ # — разделитель в строке. 
При чтении файла необходимо убрать символ #. Разбить строку на массив элементов поможет разделение 
строк с помощью метода String.Split.
 * Разбейте программу на методы (чтение, запись).
 * Новую запись внесите в конец файла.
 * Проверьте, создан файл или нет.


*/

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
        public static void Read()
        {
            Console.Clear();
            string i;
            int checker = 0;
            using (StreamReader f = new StreamReader("info.txt"))
            {
                while ((i = f.ReadLine()) != null)
                    checker++;
                if (checker == 0)
                {
                    Console.WriteLine("Файл содержащий данные о сотрудниках пуст.");
                    Console.WriteLine("Изменить файл? (Y/n)");
                    var anwser = Console.ReadLine();
                    if (anwser.ToLower().Trim() == "y")
                    {
                        f.Close();
                        Write();
                    }
                }
                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    string lineForSplitter;
                    while ((lineForSplitter = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("");
                        string[] Splitter = lineForSplitter.Split('#');
                        int checker2 = 1;
                        foreach (var print in Splitter)
                        {
                            switch (checker2)
                            {
                                case 1:
                                    Console.WriteLine($"ID:                               {print}");
                                    break;
                                case 2:
                                    Console.WriteLine($"Дата и время добавления записи:   {print}");
                                    break;
                                case 3:
                                    Console.WriteLine($"ФИО сотрудника:                   {print}");
                                    break;
                                case 4:
                                    Console.WriteLine($"Возраст сотрудника:               {print}");
                                    break;
                                case 5:
                                    Console.WriteLine($"Рост сотрудника:                  {print}");
                                    break;
                                case 6:
                                    Console.WriteLine($"Дата рождения сотрудника:         {print}");
                                    break;
                                case 7:
                                    Console.WriteLine($"Место рождения сотрудника:        {print}");
                                    break;
                            }
                            checker2++;
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
                    Console.ReadKey();
                }
            }
        }

        public static void Write()
        {
            Console.Clear();
            DateTime date = DateTime.Now;
            int checker = 1;
            string i;
            using (StreamReader f = new StreamReader("info.txt"))
            {
                while ((i = f.ReadLine()) != null)
                {
                    checker++;
                }
            }

            using (StreamWriter k = new StreamWriter("info.txt", true))
            {
                if (checker != 1)
                    k.WriteLine("");
                k.Write($"{checker}#");
                k.Write($"{date:g}#");
                Console.WriteLine("Введите ФИО нового сотрудника:");
                k.Write($"{Console.ReadLine()}#");
                Console.WriteLine("Введите возраст нового сотрудника:");
                k.Write($"{Console.ReadLine()}#");
                Console.WriteLine("Введите рост нового сотрудника:");
                k.Write($"{Console.ReadLine()}#");
                Console.WriteLine("Введите дату рождения нового сотрудника:");
                k.Write($"{Console.ReadLine()}#");
                Console.WriteLine("Введите место рождения нового сотрудника:");
                k.Write($"{Console.ReadLine()}");
            }
        }

        static void Main(string[] args)
        {
            bool waitingForResponse = true;
            while (waitingForResponse == true)
            {
                Console.WriteLine("RobCo Industries");
                Console.WriteLine("\nПеречень данных о сотрудниках.");
                Console.WriteLine("Если вы хотите получить информацию о сотрудниках, введите read.");
                Console.WriteLine("Если вы хотите записать информацию о новом сотруднике, введите edit.");
                Console.WriteLine("Если вы хотите закончить сессию данной программы, введите quit.");
                var response = Console.ReadLine();
                if (response.ToLower().Trim() == "read")
                {
                    if (File.Exists(@"info.txt"))
                        Read();
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Файл содержащий данные о сотрудниках не существует.");
                        Console.WriteLine("Создать файл? (Y/n)");
                        string anwser = Console.ReadLine();
                        if (anwser.ToLower().Trim() == "y")
                            File.Create("info.txt").Close();
                    }
                }
                else if (response == "edit")
                {
                    if (File.Exists(@"info.txt"))
                        Write();
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Файл содержащий данные о сотрудниках не существует.");
                        Console.WriteLine("Создать файл? (Y/n)");
                        string anwser = Console.ReadLine();
                        if (anwser.ToLower().Trim() == "y")
                            File.Create("info.txt").Close();
                    }
                }
                else if (response == "quit")
                {
                    waitingForResponse = false;
                }
                Console.Clear();
            }
        }
    }
}