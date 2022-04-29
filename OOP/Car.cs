using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Машина.
    /// </summary>
    class Car : Vehicle
    {
        #region Поля и свойства

        /// <summary>
        /// Цена.
        /// </summary>
        int _price;

        /// <summary>
        /// Модель машины.
        /// </summary>
        string _carModel;

        /// <summary>
        /// Модель машины.
        /// </summary>
        protected string CarModel
        {
            get => _carModel;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Модель машины не может быть без имени!");
                }

                _carModel = value;
            }
        }

        /// <summary>
        /// Цена автомобиля.
        /// </summary>
        protected int Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Цена не может быть отрицательной!");
                }

                _price = value;
            }
        }

        #endregion

        /// <summary>
        /// Добавляет записи о машине.
        /// </summary>
        /// <param name="carModel">Модель автомобиля</param>
        /// <param name="price">Цена</param>
        /// <param name="enginePower">Mощность двигателя</param>
        /// <param name="bodyType">Тип кузова</param>
        /// <param name="color">Цвет машины</param>
        public Car(string carModel, int price, int enginePower, string bodyType, string color) 
                   : base(color, enginePower, bodyType)
        {
            CarModel = carModel;
            Price = price;
        }

        /// <summary>
        /// Для использование машины.
        /// </summary>
        /// <returns>Состояние машины</returns>
        public override string StartEngine()
        {
            return $"{this.GetType().Name}: Машина заведена!";
        }

        public override string ToString()
        {
            return $"\nМодель - {CarModel}" +
                   $"\nЦена - {Price}" +
                   base.ToString();
        }
    }
}
