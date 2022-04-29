using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LinqToDB;

namespace Norbit.Crm.Hodeshenas.TaskFourteen
{
    /// <summary>
    /// Связь с БД через LinqToDB провайдер.
    /// </summary>
    public class LinqToDbProvider
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

        /// <summary>
        /// Получение из БД списка всех учителей.
        /// </summary>
        /// <returns>Список всех учителей</returns>
        public static List<Teacher> GetTeachers()
        {
            using (var db = new DbSchool(_connectionString))
            {

                var teacher = from p in db.Teacher
                              select p;

                return teacher.ToList();
            }
        }

        /// <summary>
        /// Получение учителя по айди.
        /// </summary>
        /// <param name="id">Айди учителя</param>
        /// <returns>Учитель</returns>
        public static Teacher GetTeacher(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using (var db = new DbSchool(_connectionString))
            {
                return db.Teacher
                    .Where(x => x.TeacherId == id)
                    .FirstOrDefault();
            }

        }

        /// <summary>
        /// Получение дисциплины по названию.
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Дисциплина</returns>
        public static List<Discipline> GetDisciplineByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            using (var dataBase = new DbSchool(_connectionString))
            {
                return dataBase.Discipline
                    .Where(x => x.Name.Contains(name))
                    .ToList();
            }
        }

        /// <summary>
        /// Добавление новой дисциплины.
        /// </summary>
        /// <param name="discipline">Дисциплина</param>
        /// <returns>True, если успешно, иначе - false</returns>
        public static bool InsertDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException(nameof(discipline));
            }

            using (var db = new DbSchool(_connectionString))
            {
                discipline.DisciplineId = Guid.NewGuid();
                return db.Insert(discipline) != 0;
            }
        }

        /// <summary>
        /// Обновление дисциплины.
        /// </summary>
        /// <param name="discipline">Дисциплина</param>
        /// <param name="id">Идентификатор</param>
        /// <returns>True, если успешно, иначе - false</returns>
        public static bool UpdateTeacher(Teacher teacher, Guid id)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using (var db = new DbSchool(_connectionString))
            {
                return db.Teacher
                        .Where(d => d.TeacherId == id)
                        .Set(d => d.Surname, teacher.Surname)
                        .Set(d => d.Name, teacher.Name)
                        .Set(d => d.Patronymic, teacher.Patronymic)
                        .Set(d => d.Semester, teacher.Semester)
                        .Set(d => d.DisciplineId, teacher.DisciplineId)
                        .Update() != 0;
            }
        }

        /// <summary>
        /// Удаляет учителя по id.
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>True, если успешно, иначе - false</returns>
        public static bool RemoveTeacher(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using (var db = new DbSchool(_connectionString))
            {
                return db.Teacher
                        .Where(teacher => teacher.TeacherId == id)
                        .Delete() != 0;
            }
        }
    }
}