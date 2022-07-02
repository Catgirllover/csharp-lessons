using System;

namespace ConsoleApp1
{
    struct FileEdit
    {
        #region Проверка количества линий
        private static int CheckerOfLines()
        {
            int checkerOfLines = 1;
            string fileLines;

            using (StreamReader reader = new StreamReader("info.txt"))
            {
                while ((fileLines = reader.ReadLine()) != null)
                {
                    checkerOfLines++;
                }
            }
            return checkerOfLines;
        }
        #endregion

        #region Запись файла в массив
        private static string[] FileToArray(int maxLines)
        {
            string[] fileArray = new string[maxLines];
            string fileLines;
            int cycleChecker = 1;

            using (StreamReader reader = new StreamReader("info.txt"))
            {
                while (cycleChecker < maxLines)
                {
                    fileArray[cycleChecker - 1] = reader.ReadLine();

                    cycleChecker++;
                }
            }
            return fileArray;
        }
        #endregion

        #region Запись массива в файл
        private static void ArrayToFile(string[] fileInArray, int maxLines)
        {
            using (StreamWriter write = new StreamWriter("info.txt", false))
            {
                int linesRewritten = 1;

                while (linesRewritten < maxLines)
                {
                    if (linesRewritten != maxLines - 1)
                        write.WriteLine($"{fileInArray[linesRewritten - 1]}");
                    else
                        write.Write($"{fileInArray[linesRewritten - 1]}");

                    linesRewritten++;
                }
            }
        }
        #endregion


        #region Подпрограммы редактирования
        private static void Write()
        {
            Console.Clear();
            DateTime date = DateTime.Now;


            int maxLines = CheckerOfLines();


            using (StreamWriter writer = new StreamWriter("info.txt", true))
            {
                if (maxLines != 1)
                    writer.WriteLine("");

                writer.Write($"{maxLines}#");
                writer.Write($"{date:g}#");

                Console.WriteLine("Введите ФИО нового сотрудника:");
                writer.Write($"{Console.ReadLine()}#");

                Console.WriteLine("Введите возраст нового сотрудника:");
                writer.Write($"{Console.ReadLine()}#");

                Console.WriteLine("Введите рост нового сотрудника:");
                writer.Write($"{Console.ReadLine()}#");

                Console.WriteLine("Введите дату рождения нового сотрудника:");
                writer.Write($"{Console.ReadLine()}#");

                Console.WriteLine("Введите место рождения нового сотрудника:");
                writer.Write($"{Console.ReadLine()}");
            }
        }




        private static void Rewrite()
        {
            Console.Clear();
            Console.WriteLine("Введите ID записи, которую вы хотите перезаписать.");
            int idToRewrite = int.Parse(Console.ReadLine());

            int maxLines = CheckerOfLines();

            if (idToRewrite <= maxLines && idToRewrite > 0)
            {
                string[] fileInArray = FileToArray(maxLines);
                string[] idAndTime = new string[7];
                idAndTime = (fileInArray[idToRewrite - 1]).Split('#');

                fileInArray[idToRewrite - 1] = $"{idAndTime[0]}#";
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{idAndTime[1]}#";

                Console.WriteLine("Введите ФИО нового сотрудника:");
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{Console.ReadLine()}#";

                Console.WriteLine("Введите возраст нового сотрудника:");
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{Console.ReadLine()}#";

                Console.WriteLine("Введите рост нового сотрудника:");
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{Console.ReadLine()}#";

                Console.WriteLine("Введите дату рождения нового сотрудника:");
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{Console.ReadLine()}#";

                Console.WriteLine("Введите место рождения нового сотрудника:");
                fileInArray[idToRewrite - 1] = fileInArray[idToRewrite - 1] + $"{Console.ReadLine()}";

                ArrayToFile(fileInArray, maxLines);
            }

            else
            {
                Console.WriteLine("Ваше число не является ID сотрудника.");
                Console.WriteLine("");
                Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима редактирования.");
                Console.ReadKey();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Введите ID записи, которую вы хотите удалить.");
            int idToDelete = int.Parse(Console.ReadLine());

            int maxLines = CheckerOfLines();
            Console.WriteLine(maxLines);

            if (idToDelete <= maxLines && idToDelete > 0)
            {
                string[] fileInArray = FileToArray(maxLines);

                int cycleChecker = idToDelete - 1;

                while (cycleChecker != maxLines - 2)
                {
                    string[] idChanger = new string[7];
                    idChanger = fileInArray[cycleChecker].Split('#');
                    fileInArray[cycleChecker] = fileInArray[cycleChecker + 1];
                    fileInArray[cycleChecker + 1] = 
                        $"{idChanger[0]}#{idChanger[1]}#{idChanger[2]}" +
                        $"#{idChanger[3]}#{idChanger[4]}" +
                        $"#{idChanger[5]}#{idChanger[6]}";

                    cycleChecker++;
                }

                for (int i = 1; i != maxLines - 1; i++)
                {
                    string[] idChanger = new string[7];
                    idChanger = fileInArray[i - 1].Split('#');
                    idChanger[0] = $"{i}";
                    fileInArray[i - 1] =
                        $"{idChanger[0]}#{idChanger[1]}#{idChanger[2]}" +
                        $"#{idChanger[3]}#{idChanger[4]}" +
                        $"#{idChanger[5]}#{idChanger[6]}";
                }
                ArrayToFile(fileInArray, maxLines - 1);
            }

            else
            {
                Console.WriteLine("Ваше число не является ID сотрудника.");
                Console.WriteLine("");
                Console.WriteLine("Нажмите любую клавишу чтобы выйти из режима редактирования.");
                Console.ReadKey();
            }
        }
        #endregion




        #region Выбор режима редактирования
        public void Edit()
        {
            bool isWaitingForAnwser = true;
            string anwser;

            while (isWaitingForAnwser)
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
                        checkerOfEmptiness = true;
                }

                Console.WriteLine("Если вы хотите добавить запись о новом сотруднике, введите write.");

                if (checkerOfEmptiness == false)
                {
                    Console.WriteLine("Если вы хотите изменить запись о сотруднике, введите rewrite.");
                    Console.WriteLine("Если вы хотите удалить запись о сотруднике, введите delete.");
                }

                Console.WriteLine("Если вы хотите выйти из режима редактирования, введите quit");
                anwser = Console.ReadLine();
                anwser = anwser.ToLower().Trim();

                if (anwser == "write")
                    Write();

                else if (anwser == "rewrite" && checkerOfEmptiness == false)
                    Rewrite();

                else if (anwser == "delete" && checkerOfEmptiness == false)
                    Delete();

                else if (anwser == "quit")
                    isWaitingForAnwser = false;
            }
        }
        #endregion
    }
}