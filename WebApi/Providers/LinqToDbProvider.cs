using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Norbit.Crm.Hodeshenas.FinalTaskCS
{
    /// <summary>
    /// Связь с БД через LinqToDB провайдер.
    /// </summary>
    public class LinqToDbProvider
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["LEARN_training01"].ConnectionString;

        /// <summary>
        /// Получение последней сделки пользователя.
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Последняя сделка</returns>
        public static Trade GetLastTrade(string user)
        {
            if (String.IsNullOrEmpty(user))
            {
                throw new ArgumentNullException(nameof(user), "Данные пользователя не должны содержать null!");
            }

            return GetTrades(user)
                .Where(t => t.Created < DateTime.UtcNow)
                .OrderByDescending(t => t.Created)
                .FirstOrDefault();
        }

        /// <summary>
        /// Получение сделок пользователя.
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Список сделок</returns>
        private static List<Trade> GetTrades(string user)
        {
            var queryString = "SELECT TOP(1000) Entity " +
                            "FROM [LEARN_training01].[dbo].[User] AS u " +
                            "INNER JOIN [LEARN_training01].[dbo].[Data] AS d " +
                            "ON d.UserId = u.Id  " +
                            "WHERE u.UserDomainName = @user";

            var result = new List<Trade>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@user", user);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(JsonConvert.DeserializeObject<Trade>((string)reader[0]));
                    }
                }
            }

            return result;
        }
    }
}