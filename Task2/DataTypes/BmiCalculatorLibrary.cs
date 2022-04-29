using System;

namespace Norbit.Crm.Hodeshenas.TaskTwo
{
    /// <summary>
    /// Реализация методов для вычисления индекса массы тела.
    /// </summary>
    public class BmiCalculatorLibrary
    {
        /// <summary>
        /// Проверка параметров на уловие.
        /// </summary>
        /// <param name="weight">Параметр массы</param>
        /// <param name="height">Параметр роста</param>
        /// <exception cref="ArgumentException">Параметр информации исключения</exception>
        private void CheckValue(int weight, double height)
        {
            if (weight < 0)//Проверка на отрицательное число.
            {
                throw new ArgumentException(message: "Число отрицательное!", nameof(weight));
            }
            if (height < 0)//Проверка на отрицательное число.
            {
                throw new ArgumentException(message: "Число отрицательное!", nameof(height));
            }
        }

        /// <summary>
        /// Возвращает индекс массы тела.
        /// </summary>
        /// <param name="weight">Параметр массы</param>
        /// <param name="height">Параметр роста</param>
        /// <returns>Результат расчета</returns>
        public string СalculateBodyMassIndex(int weight, double height)
        {

            if (weight == 0)
            {
                throw new ArgumentException(message: "\nОтсутствует значение!", nameof(weight));
            }
            if (height == 0)
            {
                throw new ArgumentException(message: "\nОтсутствует значение!", nameof(height));
            }

            return GetBmiString(weight, height);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private string GetBmiString(int weight, double height)
        {
            CheckValue(weight, height);

            height = height / 100.0;

            double result = Convert.ToDouble(weight) / (height * height);

            return string.Format("{0:0.00}", result) + $"\nВаш результат - {GetBmiDescription(result)}.";
        }

        /// <summary>
        /// Возвращает описание по вычисленному индексу bmi.
        /// </summary>
        /// <param name="bmi">Индекс BMI</param>
        /// <returns>Результат вычислений</returns>
        private string GetBmiDescription(double bmi)
        {
            if(bmi < 18.5 && bmi > 1)
            {
                return "недостаточный вес";
            }
            if(bmi > 18.5 && bmi < 24.9)
            {
                return "нормальный вес";
            }
            if(bmi > 25 && bmi < 29.9)
            {
                return "избыточный вес";
            }
            if(bmi > 30)
            {
                return "Ожирение";
            }

            return "такого значения нет в диапазоне ИМТ";
        }
    }
}