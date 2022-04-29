using System;
using System.Collections.Generic;
using LinqToDB;

namespace Norbit.Crm.Hodeshenas.TaskFourteen
{
    /// <summary>
    /// Связь с БД через LinqToDB провайдер.
    /// </summary>
    public class DbSchool : LinqToDB.Data.DataConnection
    {

        /// <summary>
        /// Подключение к LinqToDB провайдеру.
        /// </summary>
        /// <param name="connectionsString"></param>
        public DbSchool(string connectionsString)
            : base(ProviderName.SqlServer2017, connectionsString)
        {

        }
        public ITable<Discipline> Discipline => GetTable<Discipline>();
        public ITable<Teacher> Teacher => GetTable<Teacher>();
    }
}
