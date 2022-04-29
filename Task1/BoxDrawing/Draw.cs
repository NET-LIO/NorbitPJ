using System;

namespace BoxDrawinglibrary
{
    /// <summary>
    /// Реализует вывод результата в консоль.
    /// </summary>
    public class Draw
    {
        /// <summary>
        /// Возвращает последовательность N по возрастанию.
        /// </summary>
        /// <param name="n">Параметр А</param>
        public string GetInt(int n)
        {
            CheckValue(n);

            var resultStr = "\n";
            for (int j = 1; j <= n; j++)
            {
                resultStr += j + " ";
            }   
            
            return (resultStr + "\n").ToString();
        }

        /// <summary>
        /// Возвращает квадрат со стороной равной N.
        /// </summary>
        /// <param name="n">Размер квадрата</param>
        public string GetBox(int n)
        {
            CheckValue(n);

            var values = n / 2;
            var resultBox = "";
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    resultBox += i == values && j == values 
                        ? " " 
                        : "*";
                }
                resultBox += "\n";
            }
            return resultBox.ToString();
        }

        /// <summary>
        /// Проверка параметра value на правила.
        /// </summary>
        /// <param name="value">Входное число</param>
        public void CheckValue(int value)
        {
            if (value < 0)//Проверка на отрицательное число.
            {
                throw new ArgumentException(message:"Число отрицательное!", nameof(value));
            }
            if (value % 2 == 0)//Проверка на четность.
            {
                throw new ArgumentException(message: "Число четное!", nameof(value));
            }
            if (value < 2)//Проверка на возможность построения квадрата.
            {
                throw new ArgumentException(message: "Из такого числа квадрат не выйдет.", nameof(value));
            }
        }

        /// <summary>
        /// Реализация вывода сообщения в окно консоли с последующим завершением работы программы.
        /// </summary>
        /// <param name="ConsoleText">Параметр передаваемого значения типа "string"</param>
        public void ConsoleMessage(string consoleText)
        {
            Console.WriteLine(consoleText);
            Environment.Exit(0);
        }
    }
}
