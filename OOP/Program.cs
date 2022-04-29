using System;
using System.Globalization;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    internal class Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                GetMenu();
            }
        }

        static int GetValue(string value)
        {
            if (!int.TryParse(value, out var result))
            {
                throw new FormatException("Ты ввел не число!");
            }
            return result;
        }

        /// <summary>
        /// Выполнение задачи с окружностью.
        /// </summary>
        static void RoundTask()
        {
            Console.Clear();

            Console.WriteLine("Введите радиус - ");
            var radius = GetValue(Console.ReadLine());

            Console.WriteLine("Введите x - ");
            var x = GetValue(Console.ReadLine());

            Console.WriteLine("Введите y - ");
            var y = GetValue(Console.ReadLine());

            var round = new Round(x, y, radius);

            Console.WriteLine(round);
            Console.ReadLine();
        }

        /// <summary>
        /// Выполнение задачи с сотрудниками.
        /// </summary>
        static void UserAndEmployeeTask()
        {

            Console.Write("\nВведите ваши данные:\n" +
                          "Введите фамилию -  ");
            var surname = Console.ReadLine();

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            Console.Write("Введите отчество - ");
            var patronymic = Console.ReadLine();

            Console.Write("Введите дату рождения(Формат ДД.ММ.ГГГГ) - ");
            var dateBirthTemp = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Console.Write("Введите должность - ");
            var position = Console.ReadLine();

            Console.Write("Введите стаж - ");
            var experience = GetValue(Console.ReadLine());

            var employee = new Employee(surname, name, patronymic, dateBirthTemp, position, experience);

            Console.WriteLine($"\nЗаполненная информация сотрудника: \n{employee}");

            Console.ReadLine();
        }

        /// <summary>
        /// Выполнение задачи с классами.
        /// </summary>
        static void Hierarchy()
        {
            Console.WriteLine("Введите модель машины - ");
            var carModel = Console.ReadLine();

            Console.WriteLine("Введите цену автомобиля - ");
            var price = GetValue(Console.ReadLine());

            Console.WriteLine("Введите мощность двигателя - ");
            var enginePower = GetValue(Console.ReadLine());

            Console.WriteLine("Введите тип кузова - ");
            var manufacturerName = Console.ReadLine();

            Console.WriteLine("Введите цвет машины - ");
            var color = Console.ReadLine();

            var car = new Car(carModel, price, enginePower, manufacturerName, color);

            Console.WriteLine(car);

            Console.WriteLine(car.StartEngine());

            Console.ReadLine();
        }

        static void OnStartEngine(object sender, EventArgs e)
        {
            Console.WriteLine("Поехали!");
        }

        /// <summary>
        /// Главное меню приложения.
        /// </summary>
        static void GetMenu()
        {
            Program.ExitTheProgram += GoExit;

            Console.WriteLine("Введите номер задания:" +
                              "\n1.Задача с окружностью." +
                              "\n2.Задача с сотрудниками." +
                              "\n3.Задача с классами.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4.Выйти из программы.");
            Console.ResetColor();

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
                        RoundTask();
                        break;
                    case 2:
                        UserAndEmployeeTask();
                        break;
                    case 3:
                        Hierarchy();
                        break;
                    case 4:
                        ExitTheProgram.Invoke();
                        break;
                    default:
                        throw new ArgumentException(message: $"Вариант ({taskNumber}) не предусмотрен в программе!", nameof(taskNumber));
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Содержит указатель на метод GoExit.
        /// </summary>
        public delegate void Exit();

        /// <summary>
        /// Выход из программы.
        /// </summary>
        static event Exit ExitTheProgram;

        /// <summary>
        /// Завершение программы.
        /// </summary>
        private static void GoExit()
        {
            Environment.Exit(0);
        }
    }
}
