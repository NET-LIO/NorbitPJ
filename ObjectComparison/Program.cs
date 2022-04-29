using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Norbit.Crm.Hodeshenas.TaskThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                GetMenu();
            }
        }

        static void WordFrequency()
        {
            string text = "The computer is a COMPUTER device that process information, with surpising speed and accuracy. Computer process information ComPutER CoMPutER";

            LinkedList<string> words = new LinkedList<string>(text.Replace(".", "").Replace(",", "").Split(' '));
            int[] numberOfWords = new int[words.Count];
            var currentNode = words.First;
            string[] result = new string[words.Count];
            var wordFrequency = new WordFrequencyLibrary();

            result = wordFrequency.GetSortWords(words, numberOfWords, currentNode);

            Console.WriteLine(wordFrequency.GetStingWords(numberOfWords, result));

            Console.ReadLine();
        }

        static void DynamicArrayTest()
        {
            var dynamicArray = new DynamicArray<int>(new int[] { 0x2, 0x4, 0x9, 0x14, 0x3, 0xA, 0x17 });

            Console.WriteLine($"Исходный массив: \n\t{dynamicArray}\n");

            dynamicArray.AddRange(new int[] { 0x75, 0x20, 0x17, 0x62});
            Console.WriteLine($"Добавим в конец содержиме коллекции: \n\t{dynamicArray}\n");

            dynamicArray.Add(90);
            Console.WriteLine($"Добавим элемент со значением 90: \n\t{dynamicArray}\n");

            dynamicArray.Insert(0xA, 1);
            Console.WriteLine($"Добавим элемент со значением 10 по индексу 1: \n\t{dynamicArray}\n");

            dynamicArray.Remove(3);
            Console.WriteLine($"Удалим элемент со значением 3: \n\t{dynamicArray}\n");

            dynamicArray[2] = 0x90;
            Console.WriteLine($"Поменяем значение элемента с индексом 2: \n\t{dynamicArray}");

            var firstDynamicArray = new DynamicArray<int>(new int[] { 0x90, 0x90, 0x90, 0x17 });
            var secondDynamicArray = new DynamicArray<int>(new int[] { 0xAA, 0x90, 0x90, 0x17 });

            Console.WriteLine($"\nСравнение двух экземпляров типа DynamicArray: {firstDynamicArray.Compare(secondDynamicArray)}" +
                              $"\n\t{firstDynamicArray}\n\t{secondDynamicArray}");

            firstDynamicArray.AddRange(new int[] { 0xAA, 0x90, 0x90 });
            var firstList = new List<int>(new int[] { 0xAA, 0x90, 0x90 });

            Console.WriteLine($"\nСравнение двух экземпляров типа DynamicArray и List: {firstDynamicArray.Compare(firstList)}");

            Console.ReadLine();
        }

        /// <summary>
        /// Главное меню приложения.
        /// </summary>
        static void GetMenu()
        {
            Console.WriteLine("Введите номер задания:" +
                              "\n1.Подсчет частоты слов." +
                              "\n2.Динамический массив" +
                              "\n3.Выйти из программы");
            int taskNumber;
            if (!int.TryParse(Console.ReadLine(), out taskNumber))
            {
                Console.WriteLine("Ты ввел что-то не то, повтори попытку");
                Console.ReadLine();
                return;
            }
            try
            {
                switch (taskNumber)
                {
                    case 1:
                        WordFrequency();
                        break;
                    case 2:
                        DynamicArrayTest();
                        break;
                    case 3:
                        Process.GetCurrentProcess().Kill();
                        break;
                    default:
                        throw new ArgumentException(message: $"К такому варианту ({taskNumber}) меня мама не готовила!", nameof(taskNumber));
                }
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
