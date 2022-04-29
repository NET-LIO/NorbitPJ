using System;
using System.Collections.Generic;

namespace Norbit.Crm.Hodeshenas.TaskThree
{
    /// <summary>
    /// Методы для реализации подсчета повторяющихся слов.
    /// </summary>
    internal class WordFrequencyLibrary
    {

        /// <summary>
        /// Проверка входных пареметров.
        /// </summary>
        /// <param name="words">Задаваемый список слов</param>
        /// <param name="currentNode">Параметр типа LinkedListNode</param>
        private void ParameterCheck(LinkedList<string> words, LinkedListNode<string> currentNode)
        {
            if (words == null)
            {
                throw new ArgumentException(message: "В задаваемой переменной типа LinkedList нету значений!", nameof(words));
            }
            if (currentNode == null)
            {
                throw new ArgumentException(message: "В задаваемой переменной типа LinkedList нету значений!", nameof(words));
            }
        }

        /// <summary>
        /// Возвращает количество повторений у каждого слова.
        /// </summary>
        /// <param name="words">Список слов</param>
        /// <param name="numberOfWords">Количество повторений у каждого слова</param>
        /// <param name="currentNode">Параметр типа LinkedListNode</param>
        /// <returns>Количество повторений у каждого слова</returns>
        public string[] GetSortWords(LinkedList<string> words, int[] numberOfWords, LinkedListNode<string> currentNode)
        {

            ParameterCheck(words, currentNode);

            string[] result = new string[words.Count];

            for (var i = 0; i < words.Count; i++)
            {
                foreach (var person in words)
                {
                    if (string.Compare(currentNode.Value, person, true) == 0)
                    {
                        numberOfWords[i] += 1;
                    }
                }
                result[i] = $"Количество повторений у '{currentNode.Value}' = {(numberOfWords[i])} ";
                currentNode = currentNode.Next;
            }

            return result;
        }

        /// <summary>
        /// Возвращает результат количества повторений у каждого слова.
        /// </summary>
        /// <param name="numberOfWords">Количество повторений у каждого слова</param>
        /// <param name="result">Количество повторений у каждого слова в виде строки</param>
        /// <returns>Результат количества повторений у каждого слова</returns>
        public string GetStingWords(int[] numberOfWords, string[] result)
        {

            if (numberOfWords == null)
            {
                throw new ArgumentException(message: "В задаваемом массиве нету значений!", nameof(numberOfWords));
            }
            if (result == null)
            {
                throw new ArgumentException(message: "В задаваемом массиве нету значений!", nameof(result));
            }

            string resultString = null;

            for (var i = 0; i < numberOfWords.Length; i++)
            {
                for (var j = i + 1; j < numberOfWords.Length; j++)
                {
                    if (string.Compare(result[j], result[i], true) == 0)
                    {
                        result[j] = null;
                    }
                }
                if (result[i] != null)
                {
                    resultString+=$"{result[i]}\n";
                }
            }

            return resultString;
        }
    }
}
