using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;

namespace WebFindTutor_Client.Controllers
{
    public class GeographyController : Controller
    {
        // GET: Geography
        public ActionResult Index()
        {
            IEnumerable<GeographiesModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("GEOGRAPHies").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<GeographiesModel>>().Result;
            return View(istList);
        }
    }
}