using System;
using System.Collections.Generic;
using System.Linq;

namespace Norbit.Crm.Hodeshenas.TaskTwo
{
    /// <summary>
    /// Метод для реализации подсчета символов.
    /// </summary>
    internal class AverageWordLibrary
    {

        /// <summary>
        /// Реализует подсчета среднего числа символов в слове.
        /// </summary>
        /// <param name="inText">Входной текст</param>
        /// <returns>Возвращает число символов</returns>
        /// <exception cref="ArgumentException">Срабатывает при передаче пустого символа</exception>
        public double AverageWordLengthOutString(string inText)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException("Строка не должна быть пустой, введи еще раз!", nameof(inText));
            }

            var listOfOtherSymbol = 0;
            var wordsNumder = 0;
            var textWords = inText.Split(inText.Where(char.IsWhiteSpace).Distinct().ToArray(), 
                StringSplitOptions.RemoveEmptyEntries);
            
            for(var i = 0; i < textWords.Length; i++)
            {
                if (textWords[i].Count(char.IsLetter) != 0)
                {
                    wordsNumder++;
                    listOfOtherSymbol += textWords[i].Count(char.IsLetter);
                }
            }

            if (wordsNumder == 0)
            {
                throw new ArgumentException("Делить на 0 нельзя!", nameof(wordsNumder));
            }

            return (double)listOfOtherSymbol / (double)wordsNumder;
        }
    }
}
