using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Транспортное средство.
    /// </summary>
    abstract class Vehicle : ICondition
    {
        #region Поля и свойства

        /// <summary>
        /// Двигатель.
        /// </summary>
        int _engine;

        /// <summary>
        /// Цвет.
        /// </summary>
        string _color;

        /// <summary>
        /// Тип кузова.
        /// </summary>
        string _bodyType;

        /// <summary>
        /// Мощность двигателя.
        /// </summary>
        protected int Engine
        {
            get => _engine;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Mощность двигателя не может быть отрицательной!");
                }

                _engine = value;
            }
        }

        /// <summary>
        /// Цвет машины.
        /// </summary>
        protected string Color
        {
            get => _color;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Поле 'Цвет' не может быть пустым!");
                }

                _color = value;
            }
        }

        /// <summary>
        /// Тип кузова.
        /// </summary>
        protected string BodyType
        {
            get => _bodyType;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Тип кузова не может быть null!");
                }

                _bodyType = value;
            }
        }

        #endregion

        #region Реализация интерфейса

        public abstract string StartEngine();

        #endregion

        /// <summary>
        /// Добавляет информацию о транспортном средстве.
        /// </summary>
        /// <param name="color">Цвет машины</param>
        /// <param name="enginePower">Mощность двигателя</param>
        /// <param name="bodyType">Тип кузова</param>
        public Vehicle(string color, int enginePower, string bodyType)
        {
            Color = color;
            Engine = enginePower;
            BodyType = bodyType;
        }

        public override string ToString()
        {
            return $"\nMощность двигателя - {Engine}" +
                   $"\nТип кузова - {BodyType}" +
                   $"\nЦвет машины - {Color}";
        }
    }
}
