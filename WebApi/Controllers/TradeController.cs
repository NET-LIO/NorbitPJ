using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Norbit.Crm.Hodeshenas.FinalTaskCS
{
    /// <summary>
    /// Контроллер, отвечающий за обработку действий на главной странице.
    /// </summary>
    public class TradeController : ApiController
    {
        /// <summary>
        /// Возвращает последнюю сделку пользователя.
        /// </summary>
        /// <returns>Последняя сделка</returns>
        [HttpGet]
        [Route("api/trade/last")]
        public Trade Get()
        {
            try
            {
                return LinqToDbProvider.GetLastTrade(UserDomainName.GetUserDomainName());
            }
            catch (SqlException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
