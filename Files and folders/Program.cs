using System;
using System.IO;
using System.Text;

namespace Norbit.Crm.Hodeshenas.TaskTen
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var path = Directory.GetCurrentDirectory();
                var filePath = $"{path}\\file.txt";

                ReadFile(filePath);
                CopyFile(filePath, path);
                WriteToFile(filePath, path);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                PrintConsole(ex);
            }
        }

        static void CopyFile(string filePath, string path)
        {            
            var objective = $@"{path}\fileCopy.txt";

            var fileCopier = new FileCopier();

            fileCopier.CopyStart += CopyStart;
            fileCopier.CopyInProgress += CopyInProgress;
            fileCopier.CopyFinish += CopyFinish;

            try
            {
                fileCopier.Copy(filePath, objective, 1);
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            fileCopier.CopyStart -= CopyStart;
            fileCopier.CopyInProgress -= CopyInProgress;
            fileCopier.CopyFinish -= CopyFinish;
        }

        static void ReadFile(string filePath)
        {
            var fileContents = string.Empty;
            var stringBuilder = new StringBuilder(fileContents);

            try
            {
                stringBuilder.Append($"Содержимое файла: " +
                    $"\n{File.ReadAllText(filePath)}\n" +
                    $"\nСодержимое в байтах:\n");

                var allByte = File.ReadAllBytes(filePath);

                foreach (var b in allByte)
                {
                    stringBuilder.Append($"0x{b:X} ");
                }

                Console.WriteLine(stringBuilder);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        static void WriteToFile(string filePath, string path)
        {
            var fileToWrite = $@"{path}\fileWriteEnd.txt";

            try
            {
                string text = "\nМы в конце;)";

                using (var streamWriter = new StreamWriter(fileToWrite))
                {
                    Console.WriteLine("\nНачало записи в конец нового файла...");

                    streamWriter.WriteLine(Encoding.UTF8.GetString(File.ReadAllBytes(filePath)) + text);
                }

                Console.WriteLine($"Готово! Файл сохранен по пути {fileToWrite}");
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
        }

        static void CopyStart(object sender, EventArgs args)
        {
            Console.WriteLine("\nКопирование запущено...");
        }

        static void CopyInProgress(object sender, int arg)
        {
            Console.WriteLine($"Прогресс {arg}%");
        }

        static void CopyFinish(object sender, EventArgs args)
        {
            Console.WriteLine("\nКопирование завершено");
        }

        static void PrintConsole(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
