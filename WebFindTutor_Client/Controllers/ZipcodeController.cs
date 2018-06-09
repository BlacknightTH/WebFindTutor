using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;

namespace WebFindTutor_Client.Controllers
{
    public class ZipcodeController : Controller
    {
        // GET: Zipcode
        public ActionResult Index()
        {
            IEnumerable<ZipcodeModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ZIPCODES").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<ZipcodeModel>>().Result;
            return View(istList);
        }
    }
}