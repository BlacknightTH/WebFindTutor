using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;

namespace WebFindTutor_Client.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            IEnumerable<DistrictModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("DISTRICTS").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<DistrictModel>>().Result;
            return View(istList);
        }
    }
}