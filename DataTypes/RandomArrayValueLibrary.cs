using System;

namespace Norbit.Crm.Hodeshenas.TaskTwo
{
    /// <summary>
    /// Генерация случайных чисел массива.
    /// </summary>
    internal class RandomArrayValueLibrary
    {

        /// <summary>
        /// Проверка входного массива на наличие значений.
        /// </summary>
        /// <param name="array">Задаваемый массив</param>
        /// <exception cref="ArgumentException">Выполняется в случае выполнения условия</exception>
        private void ParameterCheck(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), message: "В задаваемом массиве нету значений!");
            }
        }

        /// <summary>
        /// Возвращает массив, заполненный случайными числами.
        /// </summary>
        /// <param name="array">Задаваемый массив</param>
        /// <returns></returns>
        public int[] CreateRandArray(int[] array)
        {

            ParameterCheck(array);

            var rand = new Random();

            for (var i = 0; i < array.Length ; i++)
            {
                array[i] = rand.Next();
            }
            return array;
        }

        /// <summary>
        /// Возвращает записанный массив.
        /// </summary>
        /// <param name="array">Задаваемый массив</param>
        /// <returns></returns>
        public string GetArrayAsString(int[] array)
        {

            ParameterCheck(array);

            var result = "";

            for(var i = 0; i < array.Length; i++)
            {
                result += $"{array[i]} ";
            }

            return result;
        }

        /// <summary>
        /// Возвращает отсортированный массив.
        /// </summary>
        /// <param name="array">Задаваемый массив</param>
        /// <returns></returns>
        public int[] SortArrayNumber(int[] array)
        {

            ParameterCheck(array);

            int tempValue;

            for (var i = 0; i < array.Length - 1 ; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        tempValue = array[i];
                        array[i] = array[j];
                        array[j] = tempValue;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Возвращает минимальное значение в массиве.
        /// </summary>
        /// <param name="array">Задаваемый массив</param>
        /// <returns>Возвращает минимальное значение</returns>
        public int GetMinArrayValue(int[] array)
        {
            ParameterCheck(array);

            var min = array[0];

            foreach (var value in array)
            {
                if (value < min)
                {
                    min = value;
                }
            }

            return min;
        }

        /// <summary>
        /// Возвращает максимальное значение в массиве.
        /// </summary>
        /// <param name="arrayGetMin">Задаваемый массив</param>
        /// <returns>Возвращает максимальное значение</returns>
        public int GetMaxArrayValue(int[] array)
        {

            ParameterCheck(array);

            var max = array[0];

            foreach (var value in array)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }
    }
}
