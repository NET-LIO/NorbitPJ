using System;


namespace Norbit.Crm.Hodeshenas.TaskTwo
{
    internal class Program
    {

        /// <summary>
        /// Главная точка входа.
        /// </summary>
        static void Main()
        {
            while(true)
            {
                Console.Clear();
                GetMenu();
            }
        }

        /// <summary>
        /// Вывод индекса массы тела.
        /// </summary>
        static void BodyMassIndex()
        {
            int weight;
            double height;
            var calculationLibrary = new BmiCalculatorLibrary();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите через 'Enter' свой вес в килограммах и рост в метрах");

                if(!int.TryParse(Console.ReadLine(), out weight) 
                    || !double.TryParse(Console.ReadLine(), out height))
                {
                    Console.WriteLine("Вы ввели не число, введите еще раз");
                    Console.ReadLine();
                    continue;
                }
                try
                {
                    Console.WriteLine($"Индекс массы тела = {calculationLibrary.СalculateBodyMassIndex(weight, height)}");
                    ForcedGarbageCleanup();
                    Console.ReadLine();
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Вывод случайных чисел массива.
        /// </summary>
        static void RandomArrayValue()
        {

            var randomArrayValue = new RandomArrayValueLibrary();

            int[] array = new int[17];
            array = randomArrayValue.CreateRandArray(array);

            Console.WriteLine($"Массив - {randomArrayValue.GetArrayAsString(array)}");

            Console.WriteLine($"Минимальное значение массива = {randomArrayValue.GetMinArrayValue(array)}");

            Console.WriteLine($"Максимальное значение массива = {randomArrayValue.GetMaxArrayValue(array)}");

            array = randomArrayValue.SortArrayNumber(array);

            Console.WriteLine($"Отсортированный массив - {randomArrayValue.GetArrayAsString(array)}");

            ForcedGarbageCleanup();

            Console.ReadLine();
        }

        /// <summary>
        /// Вывод среднего числа символов в слове.
        /// </summary>
        static void AverageWordLength()
        {
            string text;
            var averageWordLibrary = new AverageWordLibrary();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите строку: ");

                text = Console.ReadLine();

                try
                {
                    Console.WriteLine($"Средняя длина слова = {averageWordLibrary.AverageWordLengthOutString(text)}");
                    ForcedGarbageCleanup();
                    Console.ReadLine();
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Вывод и очистка памяти в управляемой куче.
        /// </summary>
        static void ForcedGarbageCleanup()
        {
            var totalMemory = GC.GetTotalMemory(false);

            Console.WriteLine($"\nОбъем памяти в байтах, которое занято в управляемой куче = {totalMemory}");
            GC.Collect(1, GCCollectionMode.Optimized);

            GC.Collect(0);

            Console.WriteLine("Объем памяти в байтах: {0}", GC.GetTotalMemory(false));
        }

        /// <summary>
        /// Главное меню приложения.
        /// </summary>
        static void GetMenu()
        {
            Console.WriteLine("Введите номер задания:" +
                            "\n1.Расчет индекса массы тела." +
                            "\n2.Генерация случайных чисел в массиве." +
                            "\n3.Определить среднюю длину слова." +
                            "\n4.Выйти из программы\n");
            int taskNumber;
            if (int.TryParse(Console.ReadLine(), out taskNumber))
            {
                try
                {
                    switch (taskNumber)
                    {
                        case 1:
                            BodyMassIndex();
                            break;
                        case 2:
                            RandomArrayValue();
                            break;
                        case 3:
                            AverageWordLength();
                            break;
                        case 4:
                            Environment.Exit(0);
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
            else
            {
                Console.Clear();
                Console.WriteLine("Ты ввел что-то не то, повтори попытку");
            }
        }
    }
}