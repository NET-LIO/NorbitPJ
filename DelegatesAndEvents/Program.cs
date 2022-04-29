using System;
using System.Diagnostics;

namespace Norbit.Crm.Hodeshenas.TaskFive
{
    internal class Program
    {

        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args"></param>
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				GetMenu();
			}
		}

        /// <summary>
        /// Оповещение о начале сортировки.
        /// </summary>
        static void OnStartSort(object sender, EventArgs e)
        {
            Console.WriteLine("\nСортировка массива...\n");
        }

        /// <summary>
        /// Оповещение о конце сортировки.
        /// </summary>
        static void OnSortEnd()
        {
            Console.WriteLine("Сортировка завершена.\n");
        }

        /// <summary>
        /// Метод упорядочивания.
        /// </summary>
        static void GenericArraySortTest()
		{
			var array = new ArbitraryArraySort();
			var mainArray = new int[] { 0x90, 0x11, 0x3A3, 0x16, 0x37, 0x777,
                                        0x17, 0x14, 0x3D3, 0xA1, 0x18, 0xDDD };

            array.StartSort += OnStartSort;
            array.SortEnd += OnSortEnd;

            Console.WriteLine($"Исходный массив - \t {array.ToString(mainArray)}");

			array.SortArray(mainArray);

			array.StartSort -= OnStartSort;
			array.SortEnd -= OnSortEnd;

            Console.WriteLine($"Отсортированный массив - {array.ToString(mainArray)}");

            Console.ReadLine();
        }

        /// <summary>
        /// Главное меню приложения.
        /// </summary>
        static void GetMenu()
        {
            Console.WriteLine("Введите номер задания:" +
                              "\n1.Упорядочивание массива произвольного типа." +
                              "\n2.Выйти из программы.");
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
                        GenericArraySortTest();
                        break;
                    case 2:
                        Process.GetCurrentProcess().Kill();
                        break;
                    default:
                        throw new ArgumentException(message: $"Вариант ({taskNumber}) не предусмотрен в программе!", nameof(taskNumber));
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
