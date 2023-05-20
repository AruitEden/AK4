//Вариант 20
using System;
using System.IO;

namespace CLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вам нужна помощь? Если да введите help");
            string? help = Console.ReadLine();

            if (help == "help") 
            {
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine("Эта программа подсчитывает общее количество подпапок и подпапок с " +
                                  "указвным атрибутом в папке путь которой вы указали \n");
                Console.WriteLine("Вам нужно ввести путь к папке БЕЗ кавычек и указать атрибут который соответствует папкам" +
                                  " которые вы хотите подсчитат (Скрытые, Только для чтения, Архивные).");
                Console.WriteLine("* Hidden - Скрытые\n* Archive - Архивные\n* ReadOnly - Только для чтения\n");
                Console.WriteLine("Если вы укажет не один из предложеных атрибутов будет подсчитано только общее " +
                                  "количество подпапок");
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine();
            }
            else
            {
                Console.Write("\nУдачи!\n");
                Console.WriteLine();
            }


            Console.WriteLine("Введите путь к папке (БЕЗ кавычек): ");
            string? path = null;
            DirectoryInfo? directory = null;
           

            try
            {
                path = Console.ReadLine();
                directory = new DirectoryInfo(path);
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Вы не ввели путь к файлу");
                Console.WriteLine("До свидания, хорошего дня!");
                Environment.Exit(-1);
            }
            
            Console.WriteLine();
            int atr = 0;

        
            if (!directory.Exists)
            {
                Console.WriteLine("Ошибка. Такой папки по указаному пути нет!");
                Environment.Exit(-1);
            }

            DirectoryInfo[] subdirs = directory.GetDirectories("*", SearchOption.AllDirectories);

            Console.WriteLine();

            Console.WriteLine("Ввидите атрибут (Hidden, Archive, ReadOnly): ");
            string? at = Console.ReadLine();


            Console.WriteLine("\nSubdirectories:");

            if (at != "Hidden" && at != "Archive" && at != "ReadOnly")
            {
                Console.WriteLine("Вы ввели неизвестный атрибут");
                Console.WriteLine($"Всего подпапок: {subdirs.Length}");
                
            }



            if (at == "Hidden")
            {
                foreach (DirectoryInfo subdir in subdirs)
                {
                    if (subdir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        atr++;
                    }
                }
                Console.WriteLine($"Всего подпапок: {subdirs.Length}");
                Console.WriteLine($"Скрытые подпапки: {atr}");
            }



            if (at == "Archive")
            {
                foreach (DirectoryInfo subdir in subdirs)
                {
                    if (subdir.Attributes.HasFlag(FileAttributes.ReadOnly))
                    {
                        atr++;
                    }
                }
                Console.WriteLine($"Всего подпапок: {subdirs.Length}");
                Console.WriteLine($"Архивные подпапки: {atr}");
            }


            if (at == "ReadOnly")
            {
                foreach (DirectoryInfo subdir in subdirs)
                {
                    if (subdir.Attributes.HasFlag(FileAttributes.Archive))
                    {
                        atr++;
                    }
                }
                Console.WriteLine($"Всего подпапок: {subdirs.Length}");
                Console.WriteLine($"Только для чтеия подпапки: {atr}");
            }
        }
    }
}




