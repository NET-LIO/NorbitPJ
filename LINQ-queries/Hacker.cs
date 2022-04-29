using System;
using System.Collections.Generic;

namespace Norbit.Crm.Hodeshenas.TaskSeven
{
    /// <summary>
    /// Содержит описания и методы для LINQ запросов.
    /// </summary>
    public class Hacker
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Достижения.
        /// </summary>
        public string Achievements;

        /// <summary>
        /// Рейтинг.
        /// </summary>
        public int Popularity;

        /// <summary>
        /// Добавляет записи о хакерах.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="achievements">Достижения</param>
        /// <param name="popularity">Рейтинг</param>
        public Hacker(string name, DateTime birthday, string achievements, int popularity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), message: "Имя не мжет содержать null!");
            }
            if (birthday == null)
            {
                throw new ArgumentNullException(nameof(popularity), message: "Дата рождения не может содержать null!");
            }
            if (string.IsNullOrEmpty(achievements))
            {
                throw new ArgumentNullException(nameof(achievements), message:"Достижения не могут содержать null!");
            }
            if (popularity < 0)
            {
                throw new ArgumentNullException(nameof(popularity), message:"Рейтинг не может быть отрицательным!");
            }

            Name = name;
            Birthday = birthday;
            Achievements = achievements;
            Popularity = popularity;
        }

        /// <summary>
        /// Вывод значений коллекции.
        /// </summary>
        /// <param name="collection">Коллекция</param>
        public static void Write<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Коллекция не может содержать null!");
            }

            foreach (var value in collection)
            {
                Console.WriteLine($"{value}\n");
            }
        }

        /// <summary>
        /// Переопределение метода ToString.
        /// </summary>
        /// <returns>Объект переведенный в строку.</returns>
        public override string ToString()
        {
            return $"{nameof(Name)} - {Name}" +
                   $"{nameof(Birthday)} - {Birthday}" +
                   $"{nameof(Achievements)} - {Achievements}" +
                   $"{nameof(Popularity)} - {Popularity}";
        }
    }
}
