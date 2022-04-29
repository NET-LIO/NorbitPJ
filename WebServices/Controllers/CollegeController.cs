using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Norbit.Crm.Hodeshenas.TaskFourteen
{
    /// <summary>
    /// Api контроллер для таблицы College.
    /// </summary>
    public class CollegeController : ApiController
    {
        /// <summary>
        /// Получение всех учителей.
        /// </summary>
        /// <returns>Список учителей.</returns>
        public List<Teacher> Get()
        {
            return LinqToDbProvider.GetTeachers();
        }

        /// <summary>
        /// Получение учителя по айди.
        /// </summary>
        /// <param name="id">Айди учителя</param>
        /// <returns>Учитель</returns>
        public Teacher Get(Guid id)
        {
            return LinqToDbProvider.GetTeacher(id);
        }

        /// <summary>
        /// Получение дисциплины по названию.
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Дисциплина</returns>
        public List<Discipline> Get(string name)
        {
            return LinqToDbProvider.GetDisciplineByName(name);
        }

        /// <summary>
        /// Добавление дисциплины.
        /// </summary>
        /// <param name="discipline">Дисциплина</param>
        /// <returns>Сообщение об успешном добавлении</returns>
        public HttpResponseMessage Post([FromBody] Discipline discipline)
        {
            LinqToDbProvider.InsertDiscipline(discipline);
            return Request.CreateResponse(HttpStatusCode.OK, "Дисциплина добавлена!");
        }

        /// <summary>
        /// Обновление учителя.
        /// </summary>
        /// <param name="teacher">Учитель</param>
        /// <param name="id">Айди учителя</param>
        /// <returns>Сообщение об успешном обновлении</returns>
        public HttpResponseMessage Put([FromBody] Teacher teacher, Guid id)
        {
            LinqToDbProvider.UpdateTeacher(teacher, id);
            return Request.CreateResponse(HttpStatusCode.OK, "Учитель обновлен!");
        }

        /// <summary>
        /// Удаление учителя по айди.
        /// </summary>
        /// <param name="id">Айди учителя</param>
        /// <returns>Сообщение об успешном удалении</returns>
        public HttpResponseMessage Delete(Guid id)
        {
            LinqToDbProvider.RemoveTeacher(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Учитель удален!");
        }
    }
}
