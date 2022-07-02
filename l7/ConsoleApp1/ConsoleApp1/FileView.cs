using System;

namespace ConsoleApp1
{
    struct FileView
    {
        #region Подпрограммы чтения
        private static void GetInfo(string lineForSplitter)
        {
            string[] Splitter = lineForSplitter.Split('#');
            Console.WriteLine("");
            Console.WriteLine($"ID:                               {Splitter[0]}");
            Console.WriteLine($"Дата и время добавления записи:   {Splitter[1]}");
            Console.WriteLine($"ФИО сотрудника:                   {Splitter[2]}");
            Console.WriteLine($"Возраст сотрудника:               {Splitter[3]}");
            Console.WriteLine($"Рост сотрудника:                  {Splitter[4]}");
            Console.WriteLine($"Дата рождения сотрудника:         {Splitter[5]}");
            Console.WriteLine($"Место рождения сотрудника:        {Splitter[6]}");
        }



        private static void ReadDate()
        {
            Console.Clear();
            Console.WriteLine("Введите с какой даты вы хотите начать сортировку.");
            DateTime firstDateSort = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите на какой дате вы хотите закончить сортировку.");
            DateTime lastDateSort = DateTime.Parse(Console.ReadLine());

            if (firstDateSort == lastDateSort || firstDateSort > lastDateSort)
            {
                Console.WriteLine("Введенные даты равны, либо начальная дата выше конечной.");
            }

            else
            {
                string lineForSplitter;

                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    while ((lineForSplitter = reader.ReadLine()) != null)
                    {
                        string[] Splitter = lineForSplitter.Split('#');

                        if (DateTime.Parse(Splitter[1]) >= firstDateSort && DateTime.Parse(Splitter[1]) <= lastDateSort)
                            GetInfo(lineForSplitter);
                    }
                }    
            }

            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
            Console.ReadKey();
        }




        private static void ReadDateSort(int maxLine)
        {
            Console.Clear();
            int cycleChecker = 0;


            while (maxLine != 0)
            {
                string lineForSplitter;

                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    while ((lineForSplitter = reader.ReadLine()) != null)
                    {
                        cycleChecker++;

                        if (cycleChecker == maxLine)
                        {
                            GetInfo(lineForSplitter);

                            cycleChecker = 0;
                            maxLine--;

                            break;
                        }
                    }
                }
            }


            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
            Console.ReadKey();
        }




        private static void ReadOne()
        {
            Console.Clear();
            int cycleChecker = 0;


            Console.WriteLine("Введите ID сотрудника, данные которого вы хотите просмотреть.");
            string idAnwser = Console.ReadLine();

            using (StreamReader reader = new StreamReader("info.txt"))
            {
                string lineForSplitter;
                bool checkIdExcistance = false;


                while ((lineForSplitter = reader.ReadLine()) != null)
                {
                    cycleChecker++;
                    if (int.Parse(idAnwser) == cycleChecker)
                    {
                        GetInfo(lineForSplitter);

                        checkIdExcistance = true;

                        break;
                    }
                }

                if (!checkIdExcistance)
                {
                    Console.WriteLine("Сотрудника с таким ID нет в списке.");
                    Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
                    Console.ReadKey();
                }

                Console.WriteLine("");
                Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
                Console.ReadKey();
            }
        }



        private static void ReadAll()
        {
            Console.Clear();

            using (StreamReader reader = new StreamReader("info.txt"))
            {
                string lineForSplitter;
                while ((lineForSplitter = reader.ReadLine()) != null)
                    GetInfo(lineForSplitter);


                Console.WriteLine("");
                Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима просмотра.");
                Console.ReadKey();
            }
        }
        #endregion




        #region Выбор режима чтения
        public void Read()
        {
            Console.Clear();
            string lines;
            int checkerOfLines = 0;
            bool checkerOfEmptiness = false;


            using (StreamReader file = new StreamReader("info.txt"))
            {
                while ((lines = file.ReadLine()) != null)
                    checkerOfLines++;

                if (checkerOfLines == 0)
                {
                    Console.WriteLine("Файл содержащий данные о сотрудниках пуст.");
                    Console.WriteLine("Нажмите любую клавишу чтобы выйти.");
                    Console.ReadKey();
                    checkerOfEmptiness = true;
                }
            }


            if (checkerOfEmptiness == false)
            {
                bool isWaitingForAnwser = true;
                string anwser;

                while (isWaitingForAnwser)
                {
                    Console.Clear(); //Сортировки по возрастанию даты нет, так как это и есть сортировка по ID
                    Console.WriteLine("Если вы хотите прочесть все записи, сортированные по ID, введите all.");
                    Console.WriteLine("Если вы хотите прочесть все записи, сортированные по убыванию дат, введите datesort.");
                    Console.WriteLine("Если вы хотите прочесть запись по ID, введите one.");
                    Console.WriteLine("Если вы хотите прочесть записи в выбранном диапазоне дат, введите date.");
                    Console.WriteLine("Если вы хотите выйти из режима просмотра записей, введите quit.");
                    anwser = Console.ReadLine();
                    anwser = anwser.ToLower().Trim();

                    if (anwser == "all")
                        ReadAll();

                    else if (anwser == "datesort")
                        ReadDateSort(checkerOfLines);

                    else if (anwser == "one")
                        ReadOne();

                    else if (anwser == "date")
                        ReadDate();

                    else if (anwser == "quit")
                        isWaitingForAnwser = false;
                }
            }
        }
        #endregion
    }
}
