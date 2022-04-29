using System;

namespace Norbit.Crm.Hodeshenas.TaskNine
{
    /// <summary>
    /// Конвертор даты.
    /// </summary>
    internal class DateConverter
    {
        /// <summary>
        /// Конвертирует дату в формате UTC в формат местного времени.
        /// </summary>
        /// <param name="utcDate">Дата в формате UTC.</param>
        /// <returns>Дата в формате местного времени..</returns>
        public static DateTime ConvertUtcToLocal(DateTime utcDate)
        {
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDate, TimeZoneInfo.Local);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Это не UTC формат!", nameof(utcDate));
            }
        }

        /// <summary>
        /// Конвертирует текст в формат DateTime.
        /// </summary>
        /// <param name="text">Входной текст</param>
        /// <returns>Дата в формате DateTime</returns>
        public DateTime ConvertToDateTime(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text), "Пустая строка или ссылка.");
            }
            try
            {
                return Convert.ToDateTime(text);
            }
            catch (FormatException e)
            {
                throw new FormatException("Формат строки не соответствует дате.", e);
            }
        }
    }
}
