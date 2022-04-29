using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    class Employee : User
    {
        #region Поля и свойства

        /// <summary>
        /// Стаж.
        /// </summary>
        private int _experience;

        /// <summary>
        /// Должность.
        /// </summary>
        private string _position;

        /// <summary>
        /// Стаж.
        /// </summary>
        public int Experience 
        {
            get => _experience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Значение не может быть отрицательным!", nameof(value));
                }

                _experience = value;
            }
        }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Position
        {
            get => _position;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Должность не может быть пустой!");
                }

                _position = value;
            }
        }

        #endregion

        /// <summary>
        /// Создает экземпляр работника.
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="dateBirthTemp">Дата рождения</param>
        /// <param name="position">Должность</param>
        /// <param name="experience">Стаж</param>
        public Employee(string surname, string name, string patronymic, DateTime dateBirthTemp, string position, int experience) 
            : base (name, surname, patronymic, dateBirthTemp)
        {
            this.Position = position;
            this.Experience = experience;
        }

        public override string ToString()
        {
            return base.ToString() + 
                $"\nДолжность - {Position}" + 
                $"\nСтаж - {Experience}";
        }
    }
}