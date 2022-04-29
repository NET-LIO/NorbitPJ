using System;

namespace Norbit.Crm.Hodeshenas.FinalTaskCS
{
    /// <summary>
    /// Доменное имя пользователя.
    /// </summary>
    public class UserDomainName
    {
        /// <summary>
        /// Возвращает доменное имя пользователя.
        /// </summary>
        /// <returns>Доменное имя пользователя</returns>
        public static string GetUserDomainName()
        {
            return @"NORBIT\Ali.Hudeshenas";
        }
    }
}