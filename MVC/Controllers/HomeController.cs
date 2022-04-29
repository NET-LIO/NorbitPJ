using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Norbit.Crm.Hodeshenas.FinalTaskCS
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Возвращает начальную страницу.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Возвращает страницу с ответом Web сервиса, вызывая метод через C#.
        /// </summary>
        /// <returns>Страница с ответом Web сервиса</returns>
        public ActionResult GetLastTradeCSharp()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://localhost:44312/api/trade/last");

                request.Credentials = CredentialCache.DefaultCredentials;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var receiveStream = response.GetResponseStream())
                    {
                        var streamReader = new StreamReader(receiveStream, Encoding.UTF8);

                        var trade = JsonConvert.DeserializeObject<Trade>(streamReader.ReadToEnd());

                        ViewBag.Created = trade.Created.ToLocalTime();
                        ViewBag.Amount = trade.Amount;
                    }
                }
            }
            catch (WebException ex)
            {
                throw new WebException("Ошибка с доступом к сервису!", ex);
            }

            return View();
        }

        /// <summary>
        /// Возвращает страницу с ответом Web сервиса, вызывая метод через JS.
        /// </summary>
        /// <returns>Страница с ответом Web сервиса</returns>
        public ActionResult GetLastTradeJS()
        {
            return View();
        }
    }
}