using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Поля и свойства

        /// <summary>
        /// Имя.
        /// </summary>
        string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        string _surname;

        /// <summary>
        /// Отчество.
        /// </summary>
        string _patronymic;

        /// <summary>
        /// Дата рождения.
        /// </summary>
        DateTime _dateBirth;

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Имя не может быть пустым!");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Фамилия не может быть пустым!!");
                }

                _surname = value;
            }
        }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(message: "Отчество не может быть пустым!!");
                }

                _patronymic = value;
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateBirth 
        { 
            get => _dateBirth;
            set
            {
                if (value >= DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения может быть больше текущей!");
                }

                _dateBirth = value;
            }
        }

        #endregion

        /// <summary>
        /// Создает экземпляр пользователя.
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="dateBirthTemp">Дата рождения</param>
        public User(string surname, string name, string patronymic, DateTime dateBirthTemp)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.DateBirth = dateBirthTemp;
        }

        /// <summary>
        /// Возраст.
        /// </summary>
        public uint Age
        {
            get
            {
                return  DateTime.Today.Month >= DateBirth.Month
                    ? (uint)(DateTime.Today.Year - DateBirth.Year)
                    : (uint)(DateTime.Today.Year - DateBirth.Year) - 1;
            }
        }

        public override string ToString()
        {
            return $"ФИО:" +
                $"\n{Surname}" +
                $"\n{Name}" +
                $"\n{Patronymic}" +
                $"\nВозраст - {Age}";
        }
    }
}
