using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Круг.
    /// </summary>
    public class Round
    {
        #region Поля и свойства

        int _x, _y, _radius;
        
        /// <summary>
        /// Координата Х.
        /// </summary>
        public int X
        {
            get => _x;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Значение не может быть отрицательным!", nameof(value));
                }

                _x = value;
            }
        }

        /// <summary>
        /// Координата Y.
        /// </summary>
        public int Y
        {
            get => _y;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Значение не может быть отрицательным!", nameof(value));
                }

                _y = value;
            }
        }

        /// <summary>
        /// Радиус окружности.
        /// </summary>
        public int Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Значение не может быть отрицательным!", nameof(value));
                }

                _radius = value;
            }
        }

        /// <summary>
        /// Вычисляет длину окружности.
        /// </summary>
        private decimal CircumscribedLength { get => Math.Truncate((decimal)(2 * _radius * Math.PI) * 1000) / 1000; }

        /// <summary>
        /// Вычисляет площадь круга.
        /// </summary>
        private decimal AreaOfCircle { get => Math.Truncate((decimal)(Math.PI * Math.Pow(_radius, 2)) * 1000) / 1000; }

        #endregion

        /// <summary>
        /// Присваивает значения.
        /// </summary>
        /// <param name="x">Параметр Х</param>
        /// <param name="y">Параметр Y</param>
        /// <param name="radiis">Радиус</param>
        public Round(int x, int y, int radiis)
        {
            X = x;
            Y = y;
            Radius = radiis;
        }

        public override string ToString()
        {
            return $"x = {X}" +
                $"\ny = {Y}" +
                $"\nradius = {Radius}" +
                $"\nДлина окружность круга = {CircumscribedLength}" +
                $"\nПлощадь круга = {AreaOfCircle}";
        }
    }
}
